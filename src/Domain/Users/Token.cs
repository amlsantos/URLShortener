using CSharpFunctionalExtensions;

namespace Domain.Users;

public class Token : ValueObject<Token>
{
    private readonly string _value;
    private Token(string value) => _value = value;

    public static Result<Token> Create(string value)
    {
        if (string.IsNullOrEmpty(value))
            return Result.Failure<Token>($"the token can not be empty");

        return Result.Success(new Token(value));
    }
    
    protected override bool EqualsCore(Token other)
    {
        return _value == other._value;
    }

    protected override int GetHashCodeCore()
    {
        return _value.GetHashCode();
    }
    
    public static Token Of(string value)
    {
        return Create(value).Value;
    }
    
    public string AsString() => _value;
}