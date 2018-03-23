using FactoryMind.Template.Data.Entities;
using FactoryMind.Template.Data.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FactoryMind.Template.Data.EntitiesConfigurators
{
    internal sealed class UserConfigurator : EntityConfigurator<User>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<User> builder)
        {
            builder.Property(u => u.Username).HasColumnName("uname");
        }
    }
}