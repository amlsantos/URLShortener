using Microsoft.AspNetCore.Identity;

namespace Domain.Users;

public class User : IdentityUser<Guid>
{
    public override Guid Id { get; set; }
    public sealed override string? UserName { get; set; }
    public sealed override string? Email { get; set; }

    private User() { }
    
    public User(string username, string email) : this()
    {
        var nameOrError = Users.UserName.Create(username);
        if (nameOrError.IsFailure)
            throw new InvalidOperationException(nameOrError.Error);

        UserName = nameOrError.Value;
        
        var emailOrError = UserEmail.Create(email);
        if (emailOrError.IsFailure)
            throw new InvalidOperationException(emailOrError.Error);

        Email = emailOrError.Value;
    }

    public User(UserName name, UserEmail email) : this()
    {
        UserName = name ?? throw new ArgumentNullException(nameof(name));
        Email = email ?? throw new ArgumentNullException(nameof(email));
    }
}