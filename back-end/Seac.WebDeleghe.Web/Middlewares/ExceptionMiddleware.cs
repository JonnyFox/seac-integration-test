using System.Net;
using System.Threading.Tasks;
using Seac.WebDeleghe.Core.Exceptions;
using Seac.WebDeleghe.Core.Extensions;
using Seac.WebDeleghe.Web.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Seac.WebDeleghe.Web.Middlewares
{
    public class ExceptionMiddleware : BaseMiddleware
    {
        public ExceptionMiddleware(RequestDelegate next) : base(next)
        { }

        public override async Task Invoke(HttpContext context)
        {
            try
            {
                await Next.Invoke(context);
            }
            catch (BadRequestException ex)
            {
                SerializeException(context, HttpStatusCode.BadRequest, ex.Cause);
            }
            catch (UnauthorizedException ex)
            {
                SerializeException(context, HttpStatusCode.Unauthorized, ex.Message);
            }
            catch (ForbiddenException ex)
            {
                SerializeException(context, HttpStatusCode.Forbidden, ex.Message);
            }
            catch (NotFoundException ex)
            {
                SerializeException(context, HttpStatusCode.NotFound, ex.Message);
            }
        }

        private static void SerializeException(HttpContext context, HttpStatusCode statusCode, object cause)
        {
            var response = context.Response;
            response.StatusCode = (int)statusCode;
            response.ContentType = "application/json";
            response.Body = null;

            if (cause != null)
            {
                response.Body = JsonConvert.SerializeObject(cause).AsStream();
            }
        }
    }

    public static class ExceptionMiddlewareExtensions
    {
        public static IApplicationBuilder UseExceptionMiddleware(this IApplicationBuilder source)
        {
            source.UseMiddleware<ExceptionMiddleware>();
            return source;
        }
    }
}
