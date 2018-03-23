using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using FactoryMind.Template.Business.Decorators;
using FactoryMind.Template.Business.Infrastructure;
using FactoryMind.Template.Data;
using FactoryMind.Template.Data.Entities;
using FactoryMind.Template.Domain.Models.Dto;

namespace FactoryMind.Template.Business.Queries
{
    [AuthenticateQuery(UserRole.Admin)]
    public sealed class GetEmploeeIncomeQuery : Query<IQueryable<EmploeeIncomeDto>>
    { }

    internal sealed class GetEmploeeIncomeQueryHandler : QueryableHandler<GetEmploeeIncomeQuery, EmploeeIncomeDto>
    {
        public GetEmploeeIncomeQueryHandler(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
        { }

        protected override IQueryable<EmploeeIncomeDto> Execute(GetEmploeeIncomeQuery query) => Context
            .EmployeeIncome
            .ProjectTo<EmploeeIncomeDto>(Mapper.ConfigurationProvider);
    }
}
