using System.Net.Mail;
using CSharpFunctionalExtensions;

namespace Domain.Users;

public class UserEmail : ValueObject<UserEmail>
{
    private readonly string _value;
    private UserEmail(string value) => _value = value;

    public static Result<UserEmail> Create(string value)
    {
        if (string.IsNullOrEmpty(value))
            return Result.Failure<UserEmail>($"the email can not be empty");
        
        var isValid = MailAddress.TryCreate(value, out _);
        if (!isValid)
            return Result.Failure<UserEmail>($"the enter a valid email address");
        
        return Result.Success(new UserEmail(value));
    }

    public string Value() => _value;
    
    public static implicit operator string(UserEmail code)
    {
        return code.Value();
    }

    protected override bool EqualsCore(UserEmail other)
    {
        return _value == other._value;
    }

    protected override int GetHashCodeCore()
    {
        return _value.GetHashCode();
    }
    
    public static UserEmail Of(string value)
    {
        return Create(value).Value;
    }
}