using System;
using System.Threading.Tasks;
using FactoryMind.Template.Business.Infrastructure;
using FactoryMind.Template.Core.Cqrs;
using FactoryMind.Template.Core.Exceptions;
using FactoryMind.Template.Data.Entities;

namespace FactoryMind.Template.Business.Decorators
{
    public class AuthenticateCommandAttribute : DecoratorAttribute
    {
        public  readonly UserRole Role;

        public AuthenticateCommandAttribute(UserRole role = UserRole.User)
        {
            Role = role;
        }

        public override Type DecoratorType => typeof(AuthenticateCommandDecorator<>);
    }

    internal sealed class AuthenticateCommandDecorator<TCommand> : CommandDecorator<TCommand>
        where TCommand : ICommand
    {
        private readonly UserRole _role;
        private readonly IUserAccessor _userAccessor;

        public AuthenticateCommandDecorator([Decoratee]ICommandHandler<TCommand> decoratee, [DecoratorMarker] AuthenticateCommandAttribute queryAttribute, IUserAccessor userAccessor)
            :base(decoratee)
        {
            _role = queryAttribute.Role;
            _userAccessor = userAccessor;
        }

        public override Task ExecuteAsync(TCommand command)
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

            return Decoratee.ExecuteAsync(command);
        }
    }
}