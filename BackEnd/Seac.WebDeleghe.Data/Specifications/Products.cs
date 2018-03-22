using Seac.WebDeleghe.Data.Entities;
using Seac.WebDeleghe.Data.Infrastructure;

namespace Seac.WebDeleghe.Data.Specifications
{
    public static partial class Spec
    {
        public static class Products
        {
            public static Specification<Product> ByName(string name) => Create<Product>(u => u.Name == name);
            public static Specification<Product> InPriceRange(decimal minPrice, decimal maxPrice) => Create<Product>(u => u.Price >= minPrice && u.Price <= maxPrice);
            public static Specification<Product> ById(int id) => Create<Product>(u => u.Id == id);
        }
    }
}