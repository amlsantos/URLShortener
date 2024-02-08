using Microsoft.AspNetCore.Identity;

namespace Domain.Users;

public sealed class User : IdentityUser<Guid>
{
    public override Guid Id { get; set; }
    public UserName Name { get; init; }
    public UserEmail UserEmail { get; init; }

    public override string? ConcurrencyStamp { get; set; }

    private User() { }
    public User(UserName name, UserEmail email) : this()
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
        UserName = name.Value;
        NormalizedUserName = name.NormalizedValue;
        
        UserEmail = email ?? throw new ArgumentNullException(nameof(email));
        Email = email.Value;
        NormalizedEmail = email.NormalizedValue;
    }
}