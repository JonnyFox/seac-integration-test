using System.Collections.Generic;
using Seac.WebDeleghe.Data.Infrastructure;

namespace Seac.WebDeleghe.Data.Entities
{
    public class User : IEntity
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public UserRole Role { get; set; }
        public ICollection<UserProduct> Products { get; set; }
    }
}