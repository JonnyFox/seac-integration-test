namespace FactoryMind.Template.Business
{
    public interface IConfigurationService
    {
        string Authority { get; }
        bool RequireHttpsMetadata { get; }
        string ApiName { get; }
        string ApiDescription { get; }
        string ResourceOwnerClientName { get; }
        string ResourceOwnerClientSecret { get; }
        string[] AllowedResourceOwnerClientScopes { get; }
    }
}