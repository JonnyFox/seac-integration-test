using FactoryMind.Template.Business.Identity;
using FactoryMind.Template.Data.Entities;

namespace FactoryMind.Template.Business.Tests.Configuration
{
    internal sealed class TestUserAccessor : IUserAccessor
    {
        private ApplicationUser _impersonatedUser;

        public ApplicationUser CurrentUser => _impersonatedUser ?? new ApplicationUser
        {
            Role = UserRole.Admin,
            Id = 1
        };

        public void Impersonate(ApplicationUser user)
        {
            _impersonatedUser = user;
        }
    }
}
