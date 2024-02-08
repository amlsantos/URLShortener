using CSharpFunctionalExtensions;

namespace Domain.Users;

public sealed class UserName : ValueObject<UserName>
{
    private UserName(string value, string normalizedValue)
    {
        Value = value;
        NormalizedValue = normalizedValue;
    }

    public string Value { get; init; }
    public string NormalizedValue { get; init; }

    public static Result<UserName> Create(string value)
    {
        if (string.IsNullOrEmpty(value))
            return Result.Failure<UserName>($"the username can not be empty");
        
        if (value.Length > 100)
            return Result.Failure<UserName>($"the username is too big");
        
        return Result.Success(new UserName(value, value.ToUpper()));
    }
    
    public static implicit operator string(UserName code)
    {
        return code.Value;
    }

    public static bool operator ==(UserName first, UserName second) => first.EqualsCore(second);

    public static bool operator !=(UserName first, UserName second) => !(first == second);

    protected override bool EqualsCore(UserName other)
    {
        return Value == other.Value && NormalizedValue == other.NormalizedValue;
    }

    protected override int GetHashCodeCore()
    {
        return Value.GetHashCode();
    }
    
    public static UserName Of(string value)
    {
        return Create(value).Value;
    }
}