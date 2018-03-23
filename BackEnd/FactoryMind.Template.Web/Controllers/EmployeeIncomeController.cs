using System.Threading.Tasks;
using FactoryMind.Template.Business.Queries;
using FactoryMind.Template.Core.Cqrs;
using FactoryMind.Template.Web.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace FactoryMind.Template.Web.Controllers
{
    [Route("api/employeeIncome")]
    public class EmployeeIncomeController : ApplicationController
    {
        public EmployeeIncomeController(Mediator mediator) : base(mediator)
        { }

        [HttpGet]
        public Task<ActionResult> GetEmployeeIncome() => 
            ToODataAsync(InvokeQueryAsync(new GetEmploeeIncomeQuery()));
    }
}
