using System;
using System.Collections.Generic;
using System.Text;
using Seac.WebDeleghe.Data.Infrastructure;

namespace Seac.WebDeleghe.Data.Entities
{
    public class Model730 : IEntity
    {
        public int Id { get; set; }
        public string TaxCode { get; set; }
        public float EmployeeIncome { get; set; }
        public float RetirementIncome { get; set; }
        public float IRPEFWithholdings { get; set; }
        public float IRPEFDeposit2016 { get; set; }
        public float IRPEFPayment2016 { get; set; }
        public float IRPEFDeposit2017 { get; set; }
        public float IRPEFRegional { get; set; }
    }
}
