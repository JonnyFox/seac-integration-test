using System.IO;
using FactoryMind.Template.Auth;
using FactoryMind.Template.Business;
using FactoryMind.Template.Web.Configuration;
using FactoryMind.Template.Web.Middlewares;
using FactoryMind.Template.Web.Middlewares.WebSockets;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FactoryMind.Template.Web
{
    public class Startup
    {
        private readonly IConfigurationRoot _configuration;

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile(@"appsettings.json", false, true)
                .AddJsonFile($@"appsettings.{env.EnvironmentName}.json", true, true)
                .AddEnvironmentVariables();
            _configuration = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddSingleton(_configuration)
                .AddBusiness(new BusinessConfigurator())
                .AddAuth(new AuthenticationConfigurator(new ConfigurationService(_configuration))) // This "new" should be removed somehow new ConfigurationService. Unfortunately we can't use DI while configuring DI
                .AddWebSocketDispatcher()
                .AddMvcCore()
                .AddJsonFormatters()
                .AddAuthorization();

            services.AddOData();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            ODataConfigurator.Configure(app.ApplicationServices);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseExceptionMiddleware();

#if DEBUG
            app.UseCors(p =>
            {
                p.AllowCredentials();
                p.AllowAnyHeader();
                p.AllowAnyMethod();
                p.AllowAnyOrigin();
            });
#endif

#if !DEBUG
            app.UseRewriter(new RewriteOptions().AddRedirectToHttps()); // Redirects each non-https request to an https request
#endif
            app.UseAuth();
            app.UseWebSocketDispatcher(WebSocketsConfigurator.Configure);
            app.UseRewriter(new RewriteOptions().Add(Html5Redirect));
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseMvc(opts => opts.EnableDependencyInjection());
        }

        private static void Html5Redirect(RewriteContext rewriteContext)
        {
            var requestPath = rewriteContext.HttpContext.Request.Path;
            if (!(requestPath.StartsWithSegments("/api") || Path.HasExtension(requestPath)))
            {
                rewriteContext.HttpContext.Request.Path = "/index.html";
            }
        }
    }
}