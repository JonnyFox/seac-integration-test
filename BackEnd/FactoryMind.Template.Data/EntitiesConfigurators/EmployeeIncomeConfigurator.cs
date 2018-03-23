using FactoryMind.Template.Data.Entities;
using FactoryMind.Template.Data.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FactoryMind.Template.Data.EntitiesConfigurators
{
    internal sealed class EmployeeIncomeConfigurator : EntityConfigurator<EmployeeIncome>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<EmployeeIncome> builder)
        { }
    }
}
