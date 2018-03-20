using System.Collections.Generic;
using FactoryMind.Template.Auth.Infrastructure;
using IdentityServer4.AccessTokenValidation;
using IdentityServer4.Models;
using IdentityServer4.Services;
using IdentityServer4.Validation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace FactoryMind.Template.Auth
{
    public interface IAuthConfigurator
    {
        IEnumerable<Client> GetClients();
        IEnumerable<ApiResource> GetApiResources();

        void ConfigureIdentityServer(IdentityServerAuthenticationOptions options);
    }

    public static class AuthConfigurationExtensions
    {
        public static IApplicationBuilder UseAuth(this IApplicationBuilder app)
        {
            app.UseAuthentication();
            app.UseIdentityServer();
            return app;
        }

        public static IServiceCollection AddAuth(this IServiceCollection services, IAuthConfigurator authenticationConfigurator)
        {
            services
                .AddIdentityServer()
                .AddDeveloperSigningCredential()
                .AddInMemoryApiResources(authenticationConfigurator.GetApiResources())
                .AddInMemoryClients(authenticationConfigurator.GetClients());

            services
                .AddTransient<IProfileService, ProfileService>()
                .AddTransient<IResourceOwnerPasswordValidator, ResourceOwnerPasswordValidator>()
                .AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services
                .AddAuthentication(IdentityServerAuthenticationDefaults.AuthenticationScheme)
                .AddIdentityServerAuthentication(authenticationConfigurator.ConfigureIdentityServer);

            return services;
        }
    }
}
