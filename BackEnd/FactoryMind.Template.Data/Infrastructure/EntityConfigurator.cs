using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FactoryMind.Template.Data.Infrastructure
{
    public interface IEntityConfigurator
    {
        void ConfigureEntity(ModelBuilder modelBuilder);
    }

    internal abstract class EntityConfigurator<TEntity> : IEntityConfigurator
        where TEntity : class, IEntity
    {
        public void ConfigureEntity(ModelBuilder modelBuilder)
        {
            var entityTypeBuilder = modelBuilder.Entity<TEntity>();
            entityTypeBuilder.HasKey(e => e.Id);
            ConfigureEntity(entityTypeBuilder);
        }

        protected abstract void ConfigureEntity(EntityTypeBuilder<TEntity> builder);
    }
}