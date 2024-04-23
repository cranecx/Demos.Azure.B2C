using System.Text.Json.Serialization;

namespace Demos.Azure.B2C.WinForms.Authentication;

public class AuthenticationSettings
{
    public string? AppId { get; set; }
    public string? B2CName { get; set; }
    public string? RedirectUri { get; set; }
    public string? PolicySignIn {  get; set; }
    public List<string> ApiScopes { get; set; } = [];

    [JsonIgnore]
    public string TenantId => $"{B2CName}.onmicrosoft.com";

    [JsonIgnore]
    public string HostName => $"{B2CName}.b2clogin.com";

    [JsonIgnore]
    public string AuthorityBase => $"https://{HostName}/tfp/{TenantId}/";

    [JsonIgnore]
    public string AuthoritySignUpSignIn => $"{AuthorityBase}{PolicySignIn}";
}
