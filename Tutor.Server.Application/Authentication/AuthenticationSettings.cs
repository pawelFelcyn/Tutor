namespace Tutor.Server.Application.Authentication;

public class AuthenticationSettings
{
    public string JwtKey { get; init; }
    public string JwtIssuer { get; init; }
    public int JwtExpireDays { get; init; }
}
