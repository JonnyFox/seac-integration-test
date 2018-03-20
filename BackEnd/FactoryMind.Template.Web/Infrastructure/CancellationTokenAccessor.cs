using System.Threading;
using FactoryMind.Template.Business;
using Microsoft.AspNetCore.Http;

namespace FactoryMind.Template.Web.Infrastructure
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