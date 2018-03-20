using FactoryMind.Template.Data.Infrastructure;

namespace FactoryMind.Template.Data.Entities
{
    public class UserProduct : IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public User User { get; set; }
        public Product Product { get; set; }
    }
}