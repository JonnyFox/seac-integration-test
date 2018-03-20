using FactoryMind.Template.Business;
using Microsoft.Extensions.Configuration;

namespace FactoryMind.Template.Web.Configuration
{
    internal sealed class ConfigurationService : IConfigurationService
    {
        private readonly IConfigurationRoot _appSettings;

        public ConfigurationService(IConfigurationRoot appSettings)
        {
            _appSettings = appSettings;
        }

#region AUTH

        private IConfigurationSection AuthSection => _appSettings.GetSection("Auth");
        public string Authority => AuthSection[nameof(Authority)];
        public bool RequireHttpsMetadata => bool.Parse(AuthSection[nameof(RequireHttpsMetadata)]);
        public string ApiName => AuthSection[nameof(ApiName)];
        public string ApiDescription => AuthSection[nameof(ApiDescription)];
        public string ResourceOwnerClientName => AuthSection[nameof(ResourceOwnerClientName)];
        public string ResourceOwnerClientSecret => AuthSection[nameof(ResourceOwnerClientSecret)];
        public string[] AllowedResourceOwnerClientScopes => AuthSection.GetSection(nameof(AllowedResourceOwnerClientScopes)).Get<string[]>();

#endregion
    }
}