namespace Domain.Urls;

public class Url
{
    public static readonly Url Empty = new(string.Empty);
    
    private readonly string _value;
    public Url(string value)
    {
        // validation
        
        _value = value;
    }

    public string AsString() => _value;
}