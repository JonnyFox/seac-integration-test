using FactoryMind.Template.Data.Entities;
using FactoryMind.Template.Data.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FactoryMind.Template.Data.EntitiesConfigurators
{
    internal sealed class ProductConfigurator : EntityConfigurator<Product>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Product> builder)
        { }
    }
}