namespace promptus_api.Settings;

public class AzureAppIdentity
{
    public required string TenantId { get; set; }
    public required string ClientId { get; set; }
    public required string ClientSecret { get; set; }
}