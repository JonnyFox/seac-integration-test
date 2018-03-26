using Seac.WebDeleghe.Business.Identity;

namespace Seac.WebDeleghe.Business
{
    public interface IUserAccessor
    {
        ApplicationUser CurrentUser { get; }
    }
}