using Microsoft.AspNet.OData.Builder;

namespace Seac.WebDeleghe.Web.Infrastructure
{
    internal interface IODataMappingConfigurator
    {
        string Name { get; }
    }

    internal interface IODataMappingConfigurator<TEntity>
        where TEntity : class
    {
        void Configure(EntitySetConfiguration<TEntity> cfg);
    }

    internal abstract class ODataMappingConfigurator<TEntity> : IODataMappingConfigurator, IODataMappingConfigurator<TEntity>
        where TEntity : class

    {
        public virtual string Name => 
            typeof(TEntity).Name.ToLowerInvariant();

        public void Configure(EntitySetConfiguration<TEntity> cfg)
        {
            // Common cfg here
            ConfigureInternal(cfg);
        }
        protected abstract void ConfigureInternal(EntitySetConfiguration<TEntity> cfg);
    }
}
