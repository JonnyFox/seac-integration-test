using Seac.WebDeleghe.Data.Entities;
using Seac.WebDeleghe.Data.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Seac.WebDeleghe.Data.EntitiesConfigurators
{
    internal sealed class ProductConfigurator : EntityConfigurator<Product>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Product> builder)
        { }
    }
}