using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace FactoryMind.Template.Web.Middlewares.WebSockets
{
    public abstract class WebSocketHandler
    {
        public abstract Task HandleAsync(HttpContext context, WebSocket socket, CancellationToken cancellationToken);
    }
}