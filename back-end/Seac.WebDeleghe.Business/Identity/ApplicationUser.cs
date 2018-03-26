using Seac.WebDeleghe.Data.Entities;

namespace Seac.WebDeleghe.Business.Identity
{
    public sealed class ApplicationUser
    {
        public int Id { get; set; }
        public UserRole Role { get; set; }
    }
}