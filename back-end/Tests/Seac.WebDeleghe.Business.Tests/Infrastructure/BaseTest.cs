using System;
using System.Threading.Tasks;
using Seac.WebDeleghe.Business.Tests.Configuration;
using Seac.WebDeleghe.Core.Cqrs;
using Microsoft.Extensions.DependencyInjection;

namespace Seac.WebDeleghe.Business.Tests.Infrastructure
{
    public abstract class BaseTest
    {
        private readonly IServiceProvider _serviceProvider;

        protected BaseTest()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddBusiness(new TestBusinessConfigurator());
            _serviceProvider = serviceCollection.BuildServiceProvider(false);
        }

        protected T Resolve<T>() => _serviceProvider.GetRequiredService<T>();

        protected Task InvokeCommandAsync<TCommand>(TCommand command)
            where TCommand : ICommand
        {
            var mediator = Resolve<Mediator>();
            return mediator.InvokeCommandAsync(command);
        }

        protected Task<TResult> InvokeQueryAsync<TResult>(IQuery<TResult> query)
        {
            var mediator = Resolve<Mediator>();
            return mediator.InvokeQueryAsync(query);
        }
    }
}
