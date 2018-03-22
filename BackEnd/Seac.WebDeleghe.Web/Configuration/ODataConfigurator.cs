using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Seac.WebDeleghe.Core.Extensions;
using Seac.WebDeleghe.Web.Infrastructure;
using Microsoft.AspNet.OData.Builder;
using Microsoft.OData.Edm;

namespace Seac.WebDeleghe.Web.Configuration
{
    internal static class ODataConfigurator
    {
        public static ODataModelBuilder ModelBuilder { get; private set; }
        public static IEdmModel EdmModel { get; private set; }
        public static IReadOnlyDictionary<Type, string> EntitySetNames { get; private set; }

        public static void Configure(IServiceProvider serviceProvider)
        {
            var builder = new ODataConventionModelBuilder(serviceProvider);

            SubscribeConfigurators(builder);
            ModelBuilder = builder;
            EdmModel = builder.GetEdmModel();
            builder.ValidateModel(EdmModel);
        }

        private static void SubscribeConfigurators(ODataModelBuilder builder)
        {
            var configuratorTypes = typeof(IODataMappingConfigurator).Assembly.GetInstantiableSubypesOf<IODataMappingConfigurator>();
            var buildEntitySetMethod = builder.GetType().GetMethods().Single(m => m.Name == nameof(builder.EntitySet) && m.IsGenericMethod && m.GetGenericArguments().Length == 1);
            var entitySetNames = new Dictionary<Type, string>();

            foreach (var configuratorType in configuratorTypes)
            {
                var entityType = configuratorType.ImplementedInterfaces.SingleOrDefault(i => !typeof(IODataMappingConfigurator).IsAssignableFrom(i))?.GenericTypeArguments[0];
                if (entityType == null)
                {
                    throw new NotSupportedException($"{configuratorType.FullName} should extend {typeof(ODataMappingConfigurator<>).FullName}");
                }

                var configurator = (IODataMappingConfigurator)Activator.CreateInstance(configuratorType);
                var entitySetName = configurator.Name;
                var entitySet = buildEntitySetMethod.MakeGenericMethod(entityType).Invoke(builder, new object[] { entitySetName }); // this means something like builder.EntitySet<User>(configurator.Name);

                var configureMethod = configurator.GetType().GetMethod(typeof(IODataMappingConfigurator<>).GetMethods().Single().Name);
                configureMethod.Invoke(configurator, new [] { entitySet });
                entitySetNames.Add(entityType, entitySetName);
            }

            EntitySetNames = new ReadOnlyDictionary<Type, string>(entitySetNames);
        }
    }
}