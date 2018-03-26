using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Seac.WebDeleghe.Business.Decorators;
using Seac.WebDeleghe.Business.Infrastructure;
using Seac.WebDeleghe.Data;
using Seac.WebDeleghe.Data.Entities;
using Seac.WebDeleghe.Domain.Models.Dto;

namespace Seac.WebDeleghe.Business.Queries
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
