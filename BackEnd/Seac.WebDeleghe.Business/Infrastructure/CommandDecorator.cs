using System.Threading.Tasks;
using Seac.WebDeleghe.Core.Cqrs;

namespace Seac.WebDeleghe.Business.Infrastructure
{
    internal abstract class CommandDecorator<TCommand> : ICommandHandler<TCommand>
        where TCommand : ICommand
    {
        internal readonly ICommandHandler<TCommand> Decoratee;

        protected CommandDecorator([Decoratee]ICommandHandler<TCommand> decoratee)
        {
            Decoratee = decoratee;
        }

        public abstract Task ExecuteAsync(TCommand command);
    }
}