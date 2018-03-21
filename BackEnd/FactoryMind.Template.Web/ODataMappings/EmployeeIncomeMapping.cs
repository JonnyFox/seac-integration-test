using FactoryMind.Template.Domain.Models.Dto;
using FactoryMind.Template.Web.Infrastructure;
using Microsoft.AspNet.OData.Builder;

namespace FactoryMind.Template.Web.ODataMappings
{
    internal sealed class EmployeeIncomeMapping : ODataMappingConfigurator<EmploeeIncomeDto>
    {
        protected override void ConfigureInternal(EntitySetConfiguration<EmploeeIncomeDto> cfg)
        {
            // Do nothing by default
        }
    }
}