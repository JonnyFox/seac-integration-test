using Seac.WebDeleghe.Data.Infrastructure;

namespace Seac.WebDeleghe.Data.Entities
{
    public class EmployeeIncome : IEntity
    {
        public int Id { get; set; }
        public string TaxCode { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CaafCode { get; set; }
        public decimal Income { get; set; }
    }
}
