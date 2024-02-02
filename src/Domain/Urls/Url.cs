namespace Domain.Urls;

public class Url
{
    private readonly string _value;
    public Url(string value)
    {
        if (string.IsNullOrEmpty(value))
            throw new InvalidOperationException("Cannot be empty");
        
        _value = value;
    }

    public string AsString() => _value;
}