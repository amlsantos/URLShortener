namespace Presentation.Users.Contracts;

public record LoginResponse
{
    public string Token { get; set; }
}