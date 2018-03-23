using System;
using System.IO;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Seac.WebDeleghe.Web.Middlewares.WebSockets
{
    public sealed class WebSocketDispatcherMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly WebSocketDispatcherMapping _mappings;

        public WebSocketDispatcherMiddleware(RequestDelegate next, WebSocketDispatcherMapping mappings)
        {
            _next = next;
            _mappings = mappings;
        }

        public async Task Invoke(HttpContext context, IServiceProvider serviceProvider)
        {
            var handlerType = _mappings.GetHandler(context.Request.Path);
            if (handlerType == null)
            {
                await _next.Invoke(context);
                return;
            }

            if (!context.WebSockets.IsWebSocketRequest)
            {
                context.Response.StatusCode = 400;
                context.Response.Body = new MemoryStream(Encoding.Default.GetBytes("This request is not supported for web sockets"));
                return;
            }

            var handler = (WebSocketHandler)serviceProvider.GetService(handlerType);
            using (var webSocket = await context.WebSockets.AcceptWebSocketAsync())
            {
                try
                {
                    await handler.HandleAsync(context, webSocket, context.RequestAborted);
                }
                finally
                {
                    if (webSocket.State != WebSocketState.Closed)
                    {
                        await webSocket.CloseAsync(WebSocketCloseStatus.Empty, "closed", context.RequestAborted);
                    }
                }
            }
        }
    }
}