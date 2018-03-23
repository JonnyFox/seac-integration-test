using FactoryMind.Template.Data.Entities;
using FactoryMind.Template.Data.Infrastructure;

namespace FactoryMind.Template.Data.Specifications
{
    public static partial class Spec
    {
        public static class UserProducts
        {
            public static Specification<UserProduct> ByUserId(int id) => Create<UserProduct>(u => u.UserId == id);
            public static Specification<UserProduct> ByProductId(int id) => Create<UserProduct>(u => u.UserId == id);
        }
    }
}