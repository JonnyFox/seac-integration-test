using FactoryMind.Template.Data.Infrastructure;

namespace FactoryMind.Template.Data.Entities
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
