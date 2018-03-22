using Seac.WebDeleghe.Business.Decorators;
using Seac.WebDeleghe.Core.Cqrs;

namespace Seac.WebDeleghe.Business.Infrastructure
{
    [AuthenticateQuery]
    public abstract class Query<TResult> : IQuery<TResult>
    { }

    [Transact]
    [AuthenticateCommand]
    public abstract class Command : ICommand
    { }
}
