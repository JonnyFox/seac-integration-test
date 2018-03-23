using System.Threading.Tasks;

namespace FactoryMind.Template.Core.Cqrs
{
    public interface IOperationHandler { }

    public interface ICommandHandler<in TCommand> : IOperationHandler
        where TCommand : ICommand
    {
        Task ExecuteAsync(TCommand command);
    }

    public interface IQueryHandler<in TQuery, TResult> : IOperationHandler
        where TQuery : IQuery<TResult>
    {
        Task<TResult> ExecuteAsync(TQuery query);
    }
}