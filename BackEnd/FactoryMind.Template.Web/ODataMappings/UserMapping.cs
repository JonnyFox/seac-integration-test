using FactoryMind.Template.Domain;
using FactoryMind.Template.Web.Infrastructure;
using Microsoft.AspNet.OData.Builder;

namespace FactoryMind.Template.Web.ODataMappings
{
    internal sealed class UserMapping : ODataMappingConfigurator<UserDto>
    {
        protected override void ConfigureInternal(EntitySetConfiguration<UserDto> cfg)
        {
            // Do nothing by default
        }
    }
}