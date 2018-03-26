using Seac.WebDeleghe.Core;
using Seac.WebDeleghe.Data.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Seac.WebDeleghe.Data
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