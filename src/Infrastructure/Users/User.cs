using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Users;

public class User : IdentityUser<Guid>
{
    public override Guid Id { get; set; }
    public UserName Name { get; }
    public sealed override string? UserName { get; set; }
    public UserEmail UserEmail { get; }
    public sealed override string? Email { get; set; }

    private User() {}
    public User(string username, string email) : this()
    {
        var nameOrError = Users.UserName.Create(username);
        if (nameOrError.IsFailure)
            throw new InvalidOperationException(nameOrError.Error);

        Name = nameOrError.Value;
        UserName = Name.Value();
        
        var emailOrError = UserEmail.Create(email);
        if (emailOrError.IsFailure)
            throw new InvalidOperationException(emailOrError.Error);

        UserEmail = emailOrError.Value;
        Email = UserEmail.Value();
    }
}