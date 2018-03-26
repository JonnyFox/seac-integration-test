using System.Collections.Generic;
using System.Linq;
using IdentityServer4;
using IdentityServer4.AccessTokenValidation;
using IdentityServer4.Models;
using Microsoft.Extensions.DependencyInjection;
using Seac.WebDeleghe.Auth;
using Seac.WebDeleghe.Business;
using Seac.WebDeleghe.Core.Extensions;

namespace Seac.WebDeleghe.Web.Configuration
{
    internal sealed class AuthenticationConfigurator : IAuthConfigurator
    {
        private readonly IConfigurationService _configurationService;

        public AuthenticationConfigurator(IConfigurationService configurationService)
        {
            _configurationService = configurationService;
        }

        public IEnumerable<Client> GetClients() => new List<Client>
        {
            new Client
            {
                AllowOfflineAccess = true,
                RefreshTokenUsage = TokenUsage.ReUse,
                RefreshTokenExpiration = TokenExpiration.Sliding,
                UpdateAccessTokenClaimsOnRefresh = true,
                ClientId = _configurationService.ResourceOwnerClientName,
                AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                ClientSecrets =
                {
                    new Secret(_configurationService.ResourceOwnerClientSecret.Sha256())
                },
                AllowedScopes = _configurationService.AllowedResourceOwnerClientScopes.Concat(IdentityServerConstants.StandardScopes.OfflineAccess).ToArray()
            }
        };

        public IEnumerable<ApiResource> GetApiResources() => new List<ApiResource>
        {
            new ApiResource(_configurationService.ApiName, _configurationService.ApiDescription),
            new ApiResource(IdentityServerConstants.StandardScopes.OfflineAccess, _configurationService.ApiDescription)
        };

        public void AddSigningCredential(IIdentityServerBuilder builder) =>
                builder.AddDeveloperSigningCredential();

        public void ConfigureIdentityServer(IdentityServerAuthenticationOptions options)
        {
            options.Authority = _configurationService.Authority;
            options.RequireHttpsMetadata = _configurationService.RequireHttpsMetadata;
            options.ApiName = _configurationService.ApiName;
        }
    }
}
