using Seac.WebDeleghe.Business.Infrastructure;
using Seac.WebDeleghe.Data.Entities;
using Seac.WebDeleghe.Domain;

namespace Seac.WebDeleghe.Business.Mappings
{
    internal sealed class UserAutomapperConfigurator : AutomapperConfigurator<User, UserDto>
    {
        // Override "Configure" to have fine graded mapping
    }
}