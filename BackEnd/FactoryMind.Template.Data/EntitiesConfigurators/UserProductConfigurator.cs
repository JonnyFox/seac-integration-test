using FactoryMind.Template.Data.Entities;
using FactoryMind.Template.Data.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FactoryMind.Template.Data.EntitiesConfigurators
{
    internal sealed class UserProductConfigurator : EntityConfigurator<UserProduct>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<UserProduct> builder)
        {
            builder.HasOne(up => up.Product).WithMany(p => p.Users).HasForeignKey(up => up.ProductId);
            builder.HasOne(up => up.User).WithMany(p => p.Products).HasForeignKey(up => up.UserId);
        }
    }
}