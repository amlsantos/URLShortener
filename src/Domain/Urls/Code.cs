using CSharpFunctionalExtensions;

namespace Domain.Urls;

public sealed class Code : ValueObject<Code>
{
    public const int Length = 7;
    private readonly string _value;
    
    private Code(string value) => _value = value;

    public static Result<Code> Create(string value)
    {
        if (string.IsNullOrEmpty(value))
            return Result.Failure<Code>($"Code can not be empty");

        if (value.Length > Length)
            return Result.Failure<Code>($"Code with invalid lenght");

        return Result.Success(new Code(value));
    }

    public string AsString() => _value;

    protected override bool EqualsCore(Code other)
    {
        return _value == other._value;
    }

    protected override int GetHashCodeCore()
    {
        return _value.GetHashCode();
    }

    public static implicit operator string(Code code)
    {
        return code.AsString();
    }

    public static Code Of(string value)
    {
        return Create(value).Value;
    }
}