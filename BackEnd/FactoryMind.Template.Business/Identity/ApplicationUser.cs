using FactoryMind.Template.Data.Entities;

namespace FactoryMind.Template.Business.Identity
{
    public sealed class ApplicationUser
    {
        public int Id { get; set; }
        public UserRole Role { get; set; }
    }
}