using FactoryMind.Template.Core;
using FactoryMind.Template.Data.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FactoryMind.Template.Data
{
    public interface IDataConfigurator
    {
        TypeReference<IDbContextConfigurator> GetDbContextConfiguratorType();
    }

    public static class DataConfigurationExtensions
    {
        public static IServiceCollection AddData(this IServiceCollection source, IDataConfigurator cfg)
        {
            source.AddSingleton(typeof(IDbContextConfigurator), cfg.GetDbContextConfiguratorType());
            return source;
        }
    }
}