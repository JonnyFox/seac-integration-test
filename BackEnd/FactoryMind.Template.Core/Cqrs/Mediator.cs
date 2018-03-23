using System;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace FactoryMind.Template.Core.Cqrs
{
    public sealed class Mediator
    {
        private readonly IServiceProvider _serviceProvider;
        private static readonly MethodInfo RequestInternalAsyncMethodInfo = typeof(Mediator).GetMethod(nameof(InvokeQueryInternalAsync), BindingFlags.Instance | BindingFlags.NonPublic);

        public Mediator(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        // AKKA.net

        public Task InvokeCommandAsync<TCommand>(TCommand command)
            where TCommand : ICommand
        {
            var handler = _serviceProvider.GetRequiredService<ICommandHandler<TCommand>>();
            return handler.ExecuteAsync(command);
        }

        public Task<TResult> InvokeQueryAsync<TResult>(IQuery<TResult> query)
        {
            var method = RequestInternalAsyncMethodInfo.MakeGenericMethod(query.GetType(), typeof(TResult));
            var result = method.Invoke(this, new object[] { query });
            return (Task<TResult>) result;
        }

        private Task<TResult> InvokeQueryInternalAsync<TQuery, TResult>(TQuery query)
            where TQuery : IQuery<TResult>
        {
            var queryHandler = _serviceProvider.GetRequiredService<IQueryHandler<TQuery, TResult>>();
            return queryHandler.ExecuteAsync(query);
        }
    }
}
