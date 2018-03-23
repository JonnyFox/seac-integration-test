using System;
using Microsoft.AspNetCore.Builder;

namespace FactoryMind.Template.Web.Configuration
{
    internal static class WebSocketsConfigurator
    {
        public static void Configure(WebSocketOptions webSocketOptions)
        {
            webSocketOptions.KeepAliveInterval = TimeSpan.FromMinutes(10);
        }
    }
}