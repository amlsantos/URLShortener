using CSharpFunctionalExtensions;

namespace Domain.Urls;

public class Url : Common.ValueObject<Url>
{
    private readonly string _value;

    private Url(string value) => _value = value;

    public static Result<Url> Create(string value)
    {
        if (string.IsNullOrEmpty(value))
            return Result.Failure<Url>($"Url can not be empty");

        return Result.Success(new Url(value));
    }

    public string AsString() => _value;
    protected override bool EqualsCore(Url other)
    {
        return _value == other._value;
    }

    protected override int GetHashCodeCore()
    {
        return _value.GetHashCode();
    }
    
    public static implicit operator string(Url url)
    {
        return url.AsString();
    }

    public static Url Of(string value)
    {
        return Create(value).Value;
    }
}