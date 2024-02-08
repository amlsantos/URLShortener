namespace Infrastructure.Users.Configurations;

public class JwtOptions
{
    public const string Jwt = nameof(Jwt);
    public string Issuer { get; set; }
    public string Audience { get; set; }
    public string ScretKey { get; set; }
    public int AccessTokenExpiration { get; set; }
}