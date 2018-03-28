using System;
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
    public sealed class GetEmploeeDetailsQuery : Query<IQueryable<EmploeeDetailsDto>>
    { }

    internal sealed class GetEmploeeDetailsQueryHandler : QueryableHandler<GetEmploeeDetailsQuery, EmploeeDetailsDto>
    {
        public GetEmploeeDetailsQueryHandler(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
        { }

        protected override IQueryable<EmploeeDetailsDto> Execute(GetEmploeeDetailsQuery query) => Context
            .Model730AA.Join(Context.Model730Pre, aa => aa.TaxCode, pre => pre.TaxCode, (aa, pre) => new
            {
                TaxCode = aa.TaxCode,
                AAEmployeeIncome = aa.EmployeeIncome,
                AARetirementIncome = aa.RetirementIncome,
                AAIRPEFWithholdings = aa.IRPEFWithholdings,
                AAIRPEFDeposit2016 = aa.IRPEFDeposit2016,
                AAIRPEFPayment2016 = aa.IRPEFPayment2016,
                AAIRPEFDeposit2017 = aa.IRPEFDeposit2017,
                AAIRPEFRegional = aa.IRPEFRegional,
                PreEmployeeIncome = pre.EmployeeIncome,
                PreRetirementIncome = pre.RetirementIncome,
                PreIRPEFWithholdings = pre.IRPEFWithholdings,
                PreIRPEFDeposit2016 = pre.IRPEFDeposit2016,
                PreIRPEFPayment2016 = pre.IRPEFPayment2016,
                PreIRPEFDeposit2017 = pre.IRPEFDeposit2017,
                PreIRPEFRegional = pre.IRPEFRegional,
                DeviationEmployeeIncome = Math.Abs(pre.EmployeeIncome - aa.EmployeeIncome),
                DeviationRetirementIncome = Math.Abs(pre.RetirementIncome - aa.RetirementIncome),
                DeviationIRPEFWithholdings = Math.Abs(pre.IRPEFWithholdings - aa.IRPEFWithholdings),
                DeviationIRPEFDeposit2016 = Math.Abs(pre.IRPEFDeposit2016 - aa.IRPEFDeposit2016),
                DeviationIRPEFPayment2016 = Math.Abs(pre.IRPEFPayment2016 - aa.IRPEFPayment2016),
                DeviationIRPEFDeposit2017 = Math.Abs(pre.IRPEFDeposit2017 - aa.IRPEFDeposit2017),
                DeviationIRPEFRegional = Math.Abs(pre.IRPEFRegional - aa.IRPEFRegional)
            })
            .ProjectTo<EmploeeDetailsDto>(Mapper.ConfigurationProvider);
    }
}
