using Seac.WebDeleghe.Core;
using Seac.WebDeleghe.Data.Configuration;

namespace Seac.WebDeleghe.Business.Tests.Configuration
{
    internal sealed class TestBusinessConfigurator : IBusinessConfigurator
    {
        public TypeReference<IDbContextConfigurator> GetDbContextConfiguratorType() =>
            TypeReference.For<IDbContextConfigurator, TestDbContextConfigurator>();

        public TypeReference<IUserAccessor> GetUserAccessorType() =>
            TypeReference.For<IUserAccessor, TestUserAccessor>();
        
        public TypeReference<ICancellationTokenAccessor> GetCancellationTokenAccessorType() =>
            TypeReference.For<ICancellationTokenAccessor, TestCancellationTokenAccessor>();

        public TypeReference<IConfigurationService> GetConfigurationServiceType() =>
            TypeReference.For<IConfigurationService, TestConfigurationService>();
    }
}