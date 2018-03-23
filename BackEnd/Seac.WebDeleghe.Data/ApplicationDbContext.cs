using System;
using System.Collections.Generic;
using System.Linq;
using Seac.WebDeleghe.Core.Extensions;
using Seac.WebDeleghe.Data.Configuration;
using Seac.WebDeleghe.Data.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Seac.WebDeleghe.Data
{
    public sealed partial class ApplicationDbContext : DbContext
    {
        private static readonly object Lock = new object();
        private static volatile bool _isCreated;

        private readonly IDbContextConfigurator _configurator;

        // Note that http://entityframework-plus.net/ was included in nuget packages in order to make batch operations
        public ApplicationDbContext(IDbContextConfigurator configurator)
        {
            _configurator = configurator;
            EnsureIsCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder) =>
            _configurator.ConfigureDbSet(builder);

        private void EnsureIsCreated()
        {
            if (_isCreated)
            {
                return;
            }

            // We should enter here only on application startup
            lock (Lock)
            {
                if (_isCreated)
                {
                    return;
                }

                Database.EnsureCreated(); // Migrate here eventually
                _isCreated = true;
            }
        }

        protected override void OnModelCreating(ModelBuilder model)
        {
            ConfigureEntities(model);

            // Other model configurations here
        }

        private static void ConfigureEntities(ModelBuilder model)
        {
            foreach (var configuratorType in GetEntitiesConfigurators())
            {
                var configurator = (IEntityConfigurator) Activator.CreateInstance(configuratorType);
                configurator.ConfigureEntity(model);
            }
        }

        private static IEnumerable<Type> GetEntitiesConfigurators() =>
            typeof(IEntityConfigurator).Assembly.DefinedTypes.Where(t => t.IsInstantiableSubclassOf<IEntityConfigurator>()).Select(t => t.AsType());
    }
}