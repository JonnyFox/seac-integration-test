using Seac.WebDeleghe.Auth;
using Seac.WebDeleghe.Business;
using Seac.WebDeleghe.Core;
using Seac.WebDeleghe.Data.Configuration;
using Seac.WebDeleghe.Web.Infrastructure;

namespace Seac.WebDeleghe.Web.Configuration
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