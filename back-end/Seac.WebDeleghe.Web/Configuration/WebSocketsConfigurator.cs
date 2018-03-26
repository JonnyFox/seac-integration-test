using System;
using Microsoft.AspNetCore.Builder;

namespace Seac.WebDeleghe.Web.Configuration
{
    internal static class WebSocketsConfigurator
    {
        public static void Configure(WebSocketOptions webSocketOptions)
        {
            webSocketOptions.KeepAliveInterval = TimeSpan.FromMinutes(10);
        }
    }
}