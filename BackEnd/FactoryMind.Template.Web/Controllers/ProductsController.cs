using System.Threading.Tasks;
using FactoryMind.Template.Business.Commands;
using FactoryMind.Template.Business.Queries;
using FactoryMind.Template.Core.Cqrs;
using FactoryMind.Template.Domain;
using FactoryMind.Template.Web.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace FactoryMind.Template.Web.Controllers
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