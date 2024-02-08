using System.Net.Mail;
using CSharpFunctionalExtensions;

namespace Domain.Users;

public sealed class UserEmail : ValueObject<UserEmail>
{
    private UserEmail(string value, string normalizedValue)
    {
        Value = value;
        NormalizedValue = normalizedValue;
    }
    
    public string Value { get; init; }
    public string NormalizedValue { get; init; }

    public static Result<UserEmail> Create(string value)
    {
        if (string.IsNullOrEmpty(value))
            return Result.Failure<UserEmail>($"the email can not be empty");

        var isValid = MailAddress.TryCreate(value, out _);
        if (!isValid)
            return Result.Failure<UserEmail>($"the enter a valid email address");
        
        return Result.Success(new UserEmail(value, value.ToUpper()));
    }
    
    public static implicit operator string(UserEmail code)
    {
        return code.Value;
    }

    protected override bool EqualsCore(UserEmail other)
    {
        return Value == other.Value && NormalizedValue == other.NormalizedValue;
    }
    
    public bool EqualsCore2(UserEmail other)
    {
        return Value == other.Value && NormalizedValue == other.NormalizedValue;
    }

    protected override int GetHashCodeCore()
    {
        return Value.GetHashCode();
    }
    
    public static UserEmail Of(string value)
    {
        return Create(value).Value;
    }
}