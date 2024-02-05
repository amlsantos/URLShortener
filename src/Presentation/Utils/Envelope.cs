namespace Presentation.Utils;

public class Envelope<T>
{
    public T Result { get; }
    public int StatusCode { get; }
    public string ErrorMessage { get; }
    public DateTime TimeGenerated { get; }

    protected internal Envelope(T result, int code, string errorMessage)
    {
        Result = result;
        StatusCode = code;
        ErrorMessage = errorMessage;
        TimeGenerated = DateTime.UtcNow;
    }
}

public class Envelope : Envelope<string>
{
    private Envelope() : base(null, 200, string.Empty) { }

    private Envelope(string errorMessage) : base(null, 400, errorMessage) { }

    public static Envelope Success()
    {
        return new Envelope();
    }
    
    public static Envelope<T> Success<T>(T result)
    {
        return new Envelope<T>(result, 200, string.Empty);
    }

    public static Envelope Error(string errorMessage)
    {
        return new Envelope(errorMessage);
    }
}