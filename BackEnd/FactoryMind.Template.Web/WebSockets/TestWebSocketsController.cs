using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;
using FactoryMind.Template.Web.Middlewares.WebSockets;
using Microsoft.AspNetCore.Http;

namespace FactoryMind.Template.Web.WebSockets
{
    [Route("/ws/test")]
    public class TestWebSocketsHandler : WebSocketHandler
    {
        // Injection works here

        public override Task HandleAsync(HttpContext context, WebSocket socket, CancellationToken cancellationToken)
        {
            //while (socket.State != WebSocketState.Closed)
            //{
            //    await Task.Delay(PollingInterval, cancellationToken);

            //    var response = new MeasurementResponseDto
            //    {
            //        TimeStamp = DateTime.UtcNow,
            //        Measures = new List<MeasureDto> { new MeasureDto { Sensor = Sensor.Pressure, Value = _measurementsService.Measure() } }
            //    };

            //    await socket.SendAsJsonAsync(response, cancellationToken, Startup.SerializerSettings);
            //}
            return Task.CompletedTask;
        }
    }
}