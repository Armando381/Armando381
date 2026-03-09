namespace TodoApi.Infrastructure.Auth;

public class JwtOptions
{
    public const string SectionName = "Jwt";
    public string Issuer { get; set; } = "TodoApi";
    public string Audience { get; set; } = "TodoApiClient";
    public string SecretKey { get; set; } = "super-secret-key-change-in-production-32chars";
    public int ExpiryMinutes { get; set; } = 60;
}
