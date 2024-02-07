using CSharpFunctionalExtensions;

namespace Infrastructure.Users;

public class UserName : ValueObject<UserName>
{
    private readonly string _value;
    private UserName(string value) => _value = value;

    public static Result<UserName> Create(string value)
    {
        if (string.IsNullOrEmpty(value))
            return Result.Failure<UserName>($"the username can not be empty");
        
        if (value.Length > 100)
            return Result.Failure<UserName>($"the username is too big");
        
        return Result.Success(new UserName(value));
    }

    public string Value() => _value;
    
    public static implicit operator string(UserName code)
    {
        return code.Value();
    }

    protected override bool EqualsCore(UserName other)
    {
        return _value == other._value;
    }

    protected override int GetHashCodeCore()
    {
        return _value.GetHashCode();
    }
    
    public static UserName Of(string value)
    {
        return Create(value).Value;
    }
}