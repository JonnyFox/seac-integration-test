using System.Linq;
using System.Threading.Tasks;
using FactoryMind.Template.Core.Cqrs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FactoryMind.Template.Web.Infrastructure
{
    [Authorize]
    public abstract class ApplicationController : ControllerBase
    {
        private readonly Mediator _mediator;

        protected ApplicationController(Mediator mediator)
        {
            _mediator = mediator;
        }

        protected Task InvokeCommandAsync<TCommand>(TCommand command)
            where TCommand : ICommand
        {
            return _mediator.InvokeCommandAsync(command);
        }

        protected Task<TResult> InvokeQueryAsync<TResult>(IQuery<TResult> query) =>
            _mediator.InvokeQueryAsync(query);

        protected async Task<ActionResult> ToODataAsync<TResult>(IQueryable<TResult> source, bool computeCount = false)
        {
            var pagedResult = await source.ToPagedResultAsync(HttpContext, computeCount);
            return Ok(pagedResult);
        }

        protected async Task<ActionResult> ToODataAsync<TResult>(Task<IQueryable<TResult>> source, bool computeCount = false) =>
            await ToODataAsync(await source, computeCount);
    }
}