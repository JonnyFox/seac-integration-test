using System;

namespace Seac.WebDeleghe.Web.Middlewares.WebSockets
{
    [AttributeUsage(AttributeTargets.Class)]
    public sealed class RouteAttribute : Attribute
    {
        public readonly string Path;

        public RouteAttribute(string path)
        {
            Path = path;
        }
    }
}