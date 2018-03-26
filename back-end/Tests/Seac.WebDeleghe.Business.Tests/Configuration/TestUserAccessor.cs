using Seac.WebDeleghe.Business.Identity;
using Seac.WebDeleghe.Data.Entities;

namespace Seac.WebDeleghe.Business.Tests.Configuration
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
