using System.Collections.Generic;
using FactoryMind.Template.Data.Infrastructure;

namespace FactoryMind.Template.Data.Entities
{
    public class Product : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public ICollection<UserProduct> Users { get; set; }
    }
}
