using System.Collections.Generic;
using IdentityServer4.AccessTokenValidation;
using IdentityServer4.Models;
using Microsoft.Extensions.DependencyInjection;
using Seac.WebDeleghe.Auth;
using Seac.WebDeleghe.Business;

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
                ClientId = _configurationService.ResourceOwnerClientName,
                AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                ClientSecrets =
                {
                    new Secret(_configurationService.ResourceOwnerClientSecret.Sha256())
                },
                AllowedScopes = _configurationService.AllowedResourceOwnerClientScopes
            }
        };

        public IEnumerable<ApiResource> GetApiResources() => new List<ApiResource>
        {
            new ApiResource(_configurationService.ApiName, _configurationService.ApiDescription)
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
