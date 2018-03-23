using FactoryMind.Template.Business.Identity;

namespace FactoryMind.Template.Business
{
    public interface IUserAccessor
    {
        ApplicationUser CurrentUser { get; }
    }
}