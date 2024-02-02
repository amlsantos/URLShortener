namespace Domain.Urls;

public class Code
{
    public const int Length = 7;
    private readonly string _value;
    
    public Code(string value)
    {
        if (string.IsNullOrEmpty(value))
            throw new InvalidOperationException("");
        
        if (value.Length > Length)
            throw new InvalidOperationException("Invalid length");
        
        _value = value;
    }

    public string AsString() => _value;
}