using System.Threading.Tasks;
using FactoryMind.Template.Business.Commands;
using FactoryMind.Template.Core.Cqrs;
using FactoryMind.Template.Web.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace FactoryMind.Template.Web.Controllers
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