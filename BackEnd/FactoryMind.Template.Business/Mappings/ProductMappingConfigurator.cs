using FactoryMind.Template.Business.Infrastructure;
using FactoryMind.Template.Data.Entities;
using FactoryMind.Template.Domain;

namespace FactoryMind.Template.Business.Mappings
{
    internal sealed class ProductAutomapperConfigurator : AutomapperConfigurator<Product, ProductDto>
    {
        // Override "Configure" to have fine graded mapping
    }
}