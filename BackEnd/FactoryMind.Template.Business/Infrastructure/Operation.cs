using FactoryMind.Template.Business.Decorators;
using FactoryMind.Template.Core.Cqrs;

namespace FactoryMind.Template.Business.Infrastructure
{
    [AuthenticateQuery]
    public abstract class Query<TResult> : IQuery<TResult>
    { }

    [Transact]
    [AuthenticateCommand]
    public abstract class Command : ICommand
    { }
}
