using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace FactoryMind.Template.Web.Infrastructure
{
    public abstract class BaseMiddleware
    {
        public readonly RequestDelegate Next;

        protected BaseMiddleware(RequestDelegate next)
        {
            Next = next;
        }

        public abstract Task Invoke(HttpContext context);
    }
}