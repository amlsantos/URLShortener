namespace Presentation.Users.Contracts;

public record LoginRequest
{
    public string Email { get; set; }
}