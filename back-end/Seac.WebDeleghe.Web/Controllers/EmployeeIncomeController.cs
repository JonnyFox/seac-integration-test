using System.Threading.Tasks;
using Seac.WebDeleghe.Business.Queries;
using Seac.WebDeleghe.Core.Cqrs;
using Seac.WebDeleghe.Web.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace Seac.WebDeleghe.Web.Controllers
{
    [Route("api/employeeIncome")]
    public class EmployeeIncomeController : ApplicationController
    {
        public EmployeeIncomeController(Mediator mediator) : base(mediator)
        { }

        [HttpGet]
        public Task<ActionResult> GetEmployeeIncome() =>
            ToODataAsync(InvokeQueryAsync(new GetEmploeeIncomeQuery()), true);
    }
}
