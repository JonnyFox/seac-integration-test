namespace FactoryMind.Template.Domain.Models.Dto
{
    public class EmploeeIncomeDto
    {
        public string Id { get; set; }
        public string TaxCode { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CaafCode { get; set; }
        public decimal Income { get; set; }
    }
}
