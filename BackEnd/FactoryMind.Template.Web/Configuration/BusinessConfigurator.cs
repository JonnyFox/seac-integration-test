using FactoryMind.Template.Auth;
using FactoryMind.Template.Business;
using FactoryMind.Template.Core;
using FactoryMind.Template.Data.Configuration;
using FactoryMind.Template.Web.Infrastructure;

namespace FactoryMind.Template.Web.Configuration
{
    internal sealed class BusinessConfigurator : IBusinessConfigurator
    {
        public TypeReference<IDbContextConfigurator> GetDbContextConfiguratorType() => 
            TypeReference.For<IDbContextConfigurator, DbContextConfigurator>();

        public TypeReference<IUserAccessor> GetUserAccessorType() =>
            TypeReference.For<IUserAccessor, UserAccessor>();

        public TypeReference<ICancellationTokenAccessor> GetCancellationTokenAccessorType() =>
            TypeReference.For<ICancellationTokenAccessor, CancellationTokenAccessor>();

        public TypeReference<IConfigurationService> GetConfigurationServiceType() =>
            TypeReference.For<IConfigurationService, ConfigurationService>();
    }
}