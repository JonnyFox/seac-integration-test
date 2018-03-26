using System.Threading;
using Seac.WebDeleghe.Business;
using Microsoft.AspNetCore.Http;

namespace Seac.WebDeleghe.Web.Infrastructure
{
    public sealed class CancellationTokenAccessor : ICancellationTokenAccessor
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CancellationTokenAccessor(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public CancellationToken CancellationToken => _httpContextAccessor.HttpContext.RequestAborted;
    }
}