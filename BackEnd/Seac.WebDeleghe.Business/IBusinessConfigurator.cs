using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using Seac.WebDeleghe.Business.Configuration;
using Seac.WebDeleghe.Business.Infrastructure;
using Seac.WebDeleghe.Core;
using Seac.WebDeleghe.Core.Cqrs;
using Seac.WebDeleghe.Core.Extensions;
using Seac.WebDeleghe.Data;
using Microsoft.Extensions.DependencyInjection;

[assembly: InternalsVisibleTo("Seac.WebDeleghe.Business.Tests")]

namespace Seac.WebDeleghe.Business
{
    public interface IBusinessConfigurator : IDataConfigurator
    {
        TypeReference<IUserAccessor> GetUserAccessorType();
        TypeReference<ICancellationTokenAccessor> GetCancellationTokenAccessorType();
        TypeReference<IConfigurationService> GetConfigurationServiceType();
    }

    public static class BusinessConfigurationExtensions 
    {
        public static IServiceCollection AddBusiness(this IServiceCollection source, IBusinessConfigurator cfg)
        {
            source
                .AddData(cfg)
                .AddScoped(typeof(IUserAccessor), cfg.GetUserAccessorType())
                .AddScoped(typeof(ICancellationTokenAccessor), cfg.GetCancellationTokenAccessorType())
                .AddScoped(typeof(IUserAccessor), cfg.GetUserAccessorType())
                .AddScoped(typeof(IConfigurationService), cfg.GetConfigurationServiceType())
                .AddScoped<Mediator>()
                .AddScoped<ApplicationDbContext>()
                .AddSingleton(AutoMapperConfigurator.CreateMapper());

            SubscribeOperationsHandlers(source);

            return source;
        }

        private static void SubscribeOperationsHandlers(IServiceCollection serviceCollection)
        {
            var operationTypes = typeof(BusinessConfigurationExtensions).Assembly
                .GetInstantiableSubypesOf<IOperation>();

            foreach (var operationType in operationTypes)
            {
                if (operationType.IsInstantiableSubclassOf<ICommand>())
                {
                    SubscribeCommand(operationType, serviceCollection);
                }
                else
                {
                    SubscribeQuery(operationType, serviceCollection);
                }
            }
        }

        private static void SubscribeCommand(Type commandType, IServiceCollection serviceCollection)
        {
            var interfaceType = typeof(ICommandHandler<>).MakeGenericType(commandType);
            var commandHandlerType = commandType.Assembly.DefinedTypes.Single(t => t.IsInstantiableSubclassOf(interfaceType));

            if (ShouldDecorate(commandType))
            {
                DecorateCommandHandler(serviceCollection, interfaceType, commandHandlerType, commandType);
            }
            else
            {
                serviceCollection.AddTransient(interfaceType, commandHandlerType);
            }
        }

        private static void SubscribeQuery(TypeInfo queryType, IServiceCollection serviceCollection)
        {
            var resultType = queryType.ImplementedInterfaces.Single(t => typeof(IOperation).IsAssignableFrom(t) && t != typeof(IOperation)).GenericTypeArguments[0];
            var interfaceType = typeof(IQueryHandler<,>).MakeGenericType(queryType, resultType);
            var queryHandlerType = queryType.Assembly.DefinedTypes.Single(t => t.IsInstantiableSubclassOf(interfaceType));

            if (ShouldDecorate(queryType))
            {
                DecorateQueryHandler(serviceCollection, interfaceType, queryHandlerType, queryType, resultType);
            }
            else
            {
                serviceCollection.AddTransient(interfaceType, queryHandlerType);
            }
        }

        private static bool ShouldDecorate(MemberInfo operationType) =>
            operationType.GetCustomAttributes<DecoratorAttribute>().Any();

        private static void DecorateQueryHandler(IServiceCollection serviceCollection, Type interfaceType, Type queryHandlerType, Type queryType, Type resultType)
        {
            serviceCollection.AddTransient(interfaceType, sp =>
            {
                var handler = CreateHandler(sp, queryHandlerType);
                var decoratorAttributes = GetDecoratorAttributes(queryType);

                foreach (var decoratorAttribute in decoratorAttributes)
                {
                    var decoratorType = decoratorAttribute.DecoratorType.MakeGenericType(queryType, resultType);
                    handler = Decorate(decoratorAttribute, decoratorType, handler, sp);
                }

                return handler;
            });
        }

        private static void DecorateCommandHandler(IServiceCollection serviceCollection, Type interfaceType, Type commandHandlerType, Type commandType)
        {
            serviceCollection.AddTransient(interfaceType, sp =>
            {
                var handler = CreateHandler(sp, commandHandlerType);
                var decoratorAttributes = GetDecoratorAttributes(commandType);

                foreach (var decoratorAttribute in decoratorAttributes)
                {
                    var decoratorType = decoratorAttribute.DecoratorType.MakeGenericType(commandType);
                    handler = Decorate(decoratorAttribute, decoratorType, handler, sp);
                }

                return handler;
            });
        }

        private static object Decorate(DecoratorAttribute decoratorMarker, Type decoratorType, object decoratee, IServiceProvider serviceProvider)
        {
            var constructors = decoratorType.GetConstructors();
            if (constructors.Length == 0 || constructors.Length > 1)
            {
                throw new NotSupportedException($"Decorator of type {decoratorType.FullName} must have only one public constructor");
            }

            var constructorParams = constructors[0].GetParameters();
            var decorateeWasFound = false;

            var parametersInstances = constructorParams.Select(p =>
            {
                if (p.GetCustomAttribute<DecorateeAttribute>() == null)
                {
                    return p.GetCustomAttribute<DecoratorMarkerAttribute>() == null
                        ? serviceProvider.GetRequiredService(p.ParameterType)
                        : decoratorMarker;
                }

                decorateeWasFound = true;
                return decoratee;
            }).ToArray();

            if (!decorateeWasFound)
            {
                throw new NotSupportedException($"Decorator of type {decoratorType.FullName} must declare a [{nameof(Decorate)}] constructor parameter");
            }

            return Activator.CreateInstance(decoratorType, parametersInstances);
        }

        private static object CreateHandler(IServiceProvider sp, Type handlerType)
        {
            var constructors = handlerType.GetConstructors();
            if (constructors.Length == 0 || constructors.Length > 1)
            {
                throw new NotSupportedException($"Handler of type {handlerType.FullName} must have only one public constructor");
            }

            var constructorParams = constructors[0].GetParameters();
            var parametersInstances = constructorParams.Select(p => sp.GetRequiredService(p.ParameterType));
            return Activator.CreateInstance(handlerType, parametersInstances.ToArray());
        }

        private static IEnumerable<DecoratorAttribute> GetDecoratorAttributes(MemberInfo operationType)
        {
            var alreadyDecorated = new HashSet<Type>();
            var attributes = operationType.GetCustomAttributes<DecoratorAttribute>().OrderBy(a => a.Priority);

            foreach (var attribute in attributes)
            {
                var attributeType = attribute.GetType();
                if (alreadyDecorated.Contains(attributeType))
                {
                    continue;
                }

                alreadyDecorated.Add(attributeType);
                yield return attribute;
            }
        }
    }
}
