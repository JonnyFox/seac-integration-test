using FactoryMind.Template.Business.Infrastructure;
using FactoryMind.Template.Data.Entities;
using FactoryMind.Template.Domain;

namespace FactoryMind.Template.Business.Mappings
{
    internal sealed class UserProductAutomapperConfigurator : AutomapperConfigurator<UserProduct, UserProductDto>
    {
        // Override "Configure" to have fine graded mapping
    }
}