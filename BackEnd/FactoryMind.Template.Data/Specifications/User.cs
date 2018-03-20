using FactoryMind.Template.Data.Entities;
using FactoryMind.Template.Data.Infrastructure;

namespace FactoryMind.Template.Data.Specifications
{
    public static partial class Spec
    {
        public static class Users
        {
            public static Specification<User> ByUsername(string username) => Create<User>(u => u.Username == username);
            public static Specification<User> ById(int id) => Create<User>(u => u.Id == id);
        }
    }
}