using Seac.WebDeleghe.Business.Infrastructure;
using Seac.WebDeleghe.Data.Entities;
using Seac.WebDeleghe.Domain;

namespace Seac.WebDeleghe.Business.Mappings
{
    internal sealed class UserProductAutomapperConfigurator : AutomapperConfigurator<UserProduct, UserProductDto>
    {
        // Override "Configure" to have fine graded mapping
    }
}