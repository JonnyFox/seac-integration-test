using System.Threading.Tasks;
using Seac.WebDeleghe.Business.Commands;
using Seac.WebDeleghe.Core.Cqrs;
using Seac.WebDeleghe.Web.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace Seac.WebDeleghe.Web.Controllers
{
    [Route("api/users")]
    public class UsersController : ApplicationController
    {
        public UsersController(Mediator mediator) : base(mediator)
        { }

        [HttpPost("products/{productId}/buy")]
        public Task BuyProductAsync(int productId) =>
            InvokeCommandAsync(new BuyProductCommand(productId));
    }
}