using System.Threading.Tasks;
using FactoryMind.Template.Core.Cqrs;

namespace FactoryMind.Template.Business.Infrastructure
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