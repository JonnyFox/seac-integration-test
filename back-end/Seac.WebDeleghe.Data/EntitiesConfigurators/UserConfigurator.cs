using Seac.WebDeleghe.Data.Entities;
using Seac.WebDeleghe.Data.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Seac.WebDeleghe.Data.EntitiesConfigurators
{
    internal sealed class UserConfigurator : EntityConfigurator<User>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<User> builder)
        {
            builder.Property(u => u.Username).HasColumnName("uname");
        }
    }
}