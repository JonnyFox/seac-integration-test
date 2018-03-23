using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using FactoryMind.Template.Business.Infrastructure;
using FactoryMind.Template.Core.Extensions;

namespace FactoryMind.Template.Business.Configuration
{
    internal static class AutoMapperConfigurator
    {
        public static IMapper CreateMapper()
        {
            Mapper.Initialize(cfg =>
            {
                foreach (var mapper in GetMappers())
                {
                    mapper.Configre(cfg);
                }
            });

            Mapper.AssertConfigurationIsValid();
            return Mapper.Instance;
        }

        private static IEnumerable<IAutomapperConfigurator> GetMappers() => typeof(IAutomapperConfigurator).Assembly
            .GetInstantiableSubypesOf<IAutomapperConfigurator>()
            .Select(t => (IAutomapperConfigurator)Activator.CreateInstance(t.AsType()));
    }
}
