using System;
using System.Threading.Tasks;
using FactoryMind.Template.Business.Infrastructure;
using FactoryMind.Template.Core.Cqrs;
using FactoryMind.Template.Core.Exceptions;
using FactoryMind.Template.Data.Entities;

namespace FactoryMind.Template.Business.Decorators
{
    public class AuthenticateQueryAttribute : DecoratorAttribute
    {
        public  readonly UserRole Role;

        public AuthenticateQueryAttribute(UserRole role = UserRole.User)
        {
            Role = role;
        }

        public override Type DecoratorType => typeof(AuthenticateQueryDecorator<,>);
    }

    internal sealed class AuthenticateQueryDecorator<TQuery, TResult> : QueryDecorator<TQuery, TResult>
        where TQuery : IQuery<TResult>
    {
        private readonly UserRole _role;
        private readonly IUserAccessor _userAccessor;

        public AuthenticateQueryDecorator([Decoratee]IQueryHandler<TQuery, TResult> decoratee, [DecoratorMarker] AuthenticateQueryAttribute queryAttribute, IUserAccessor userAccessor)
            :base(decoratee)
        {
            _role = queryAttribute.Role;
            _userAccessor = userAccessor;
        }

        public override Task<TResult> ExecuteAsync(TQuery query)
        {
            var currentUser = _userAccessor.CurrentUser;
            if (currentUser == null)
            {
                throw new UnauthorizedException("Questa operazione non supporta accessi anonimi");
            }

            var role = currentUser.Role;
            if (!role.HasFlag(_role))
            {
                throw new ForbiddenException("Privilegi insufficienti per eseguire l'operazione");
            }

            return Decoratee.ExecuteAsync(query);
        }
    }
}
