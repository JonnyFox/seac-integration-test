using Seac.WebDeleghe.Data.Entities;
using Seac.WebDeleghe.Data.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Seac.WebDeleghe.Data.EntitiesConfigurators
{
    internal sealed class EmployeeIncomeConfigurator : EntityConfigurator<EmployeeIncome>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<EmployeeIncome> builder)
        { }
    }
}
