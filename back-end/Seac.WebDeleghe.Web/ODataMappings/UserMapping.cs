using Seac.WebDeleghe.Domain;
using Seac.WebDeleghe.Web.Infrastructure;
using Microsoft.AspNet.OData.Builder;

namespace Seac.WebDeleghe.Web.ODataMappings
{
    internal sealed class UserMapping : ODataMappingConfigurator<UserDto>
    {
        protected override void ConfigureInternal(EntitySetConfiguration<UserDto> cfg)
        {
            // Do nothing by default
        }
    }
}