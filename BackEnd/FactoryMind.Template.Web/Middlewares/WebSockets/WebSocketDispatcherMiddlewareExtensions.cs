using System;
using System.IO;
using System.Net.WebSockets;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FactoryMind.Template.Core.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace FactoryMind.Template.Web.Middlewares.WebSockets
{
    public static class WebSocketDispatcherMiddlewareExtensions
    {
        public static IApplicationBuilder UseWebSocketDispatcher(this IApplicationBuilder app, Action<WebSocketOptions> opts)
        {
            if (opts == null)
            {
                throw new ArgumentNullException(nameof(opts));
            }

            var options = new WebSocketOptions();
            opts.Invoke(options);

            app.UseWebSockets(options);

            var mappings = app.ApplicationServices.GetRequiredService<WebSocketDispatcherMapping>();
            app.UseMiddleware(typeof(WebSocketDispatcherMiddleware), mappings);

            return app;
        }

        public static IServiceCollection AddWebSocketDispatcher(this IServiceCollection services, Assembly handlersAssembly = null)
        {
            handlersAssembly = handlersAssembly ?? typeof(WebSocketHandler).Assembly;
            var handlers = handlersAssembly.GetInstantiableSubypesOf<WebSocketHandler>();
            var mappings = new WebSocketDispatcherMapping();

            foreach (var handler in handlers)
            {
                var path = handler.GetCustomAttribute<RouteAttribute>()?.Path;
                if (path == null)
                {
                    throw new NotSupportedException($"Class of type {handler.FullName} has to be marked with {typeof(RouteAttribute).FullName}");
                }

                if (!path.StartsWith("/"))
                {
                    path = $"/{path}";
                }

                services.AddScoped(handler);
                mappings.AddHandler(path, handler);
            }

            services.AddSingleton(mappings);

            return services;
        }

        public static Task SendAsJsonAsync<T>(this WebSocket source, T data, CancellationToken cancellationToken = default(CancellationToken), JsonSerializerSettings settings = null)
        {
            var serializedData = JsonConvert.SerializeObject(data, settings);

            var encoded = Encoding.UTF8.GetBytes(serializedData);
            var buffer = new ArraySegment<byte>(encoded, 0, encoded.Length);
            return source.SendAsync(buffer, WebSocketMessageType.Text, true, cancellationToken);
        }

        public static async Task<T> ReadJsonAsync<T>(this WebSocket source, CancellationToken cancellationToken = default(CancellationToken), JsonSerializerSettings settings = null)
        {
            var buffer = new ArraySegment<byte>(new byte[8192]);
            using (var ms = new MemoryStream())
            {
                WebSocketReceiveResult result;
                do
                {
                    result = await source.ReceiveAsync(buffer, CancellationToken.None);
                    await ms.WriteAsync(buffer.Array, buffer.Offset, result.Count, cancellationToken);
                }
                while (!result.EndOfMessage);

                ms.Seek(0, SeekOrigin.Begin);

                using (var reader = new StreamReader(ms, Encoding.UTF8))
                {
                    var serializedResult = await reader.ReadToEndAsync();
                    return JsonConvert.DeserializeObject<T>(serializedResult, settings);
                }
            }
        }
    }
}