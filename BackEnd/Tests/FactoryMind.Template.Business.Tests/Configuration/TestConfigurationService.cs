namespace FactoryMind.Template.Business.Tests.Configuration
{
    internal sealed class TestConfigurationService : IConfigurationService
    {
        public string Authority { get; } = null;
        public bool RequireHttpsMetadata { get; } = false;
        public string ApiName { get; } = null;
        public string ApiDescription { get; } = null;
        public string ResourceOwnerClientName { get; } = null;
        public string ResourceOwnerClientSecret { get; } = null;
        public string[] AllowedResourceOwnerClientScopes { get; } = null;
    }
}