using Seac.WebDeleghe.Domain.Models.Dto;
using Seac.WebDeleghe.Web.Infrastructure;
using Microsoft.AspNet.OData.Builder;

namespace Seac.WebDeleghe.Web.ODataMappings
{
    internal sealed class EmployeeIncomeMapping : ODataMappingConfigurator<EmploeeIncomeDto>
    {
        protected override void ConfigureInternal(EntitySetConfiguration<EmploeeIncomeDto> cfg)
        {
            // Do nothing by default
        }
    }
}