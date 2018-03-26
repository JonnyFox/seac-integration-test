using System.Threading.Tasks;
using Seac.WebDeleghe.Business.Commands;
using Seac.WebDeleghe.Business.Queries;
using Seac.WebDeleghe.Core.Cqrs;
using Seac.WebDeleghe.Domain;
using Seac.WebDeleghe.Web.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace Seac.WebDeleghe.Web.Controllers
{
    [Route("api/products")]
    public class ProductsController : ApplicationController
    {
        public ProductsController(Mediator mediator) : base(mediator)
        { }

        [HttpGet("{productId}/users")]
        public Task<ActionResult> GetProductUsersAsync(int productId) =>
            ToODataAsync(InvokeQueryAsync(new GetProductUsersQuery(productId)));

        [HttpPost]
        public Task CreateProductAsync([FromBody] ProductDto product) =>
            InvokeCommandAsync(new CreateProductCommand(product));
    }
}