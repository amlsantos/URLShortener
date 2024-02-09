namespace Presentation.Common;

public class Envelope<T>
{
    public T Result { get; }
    public int StatusCode { get; }
    public string ErrorMessage { get; }
    public IReadOnlyDictionary<string, string[]> ValidationErrors { get; init; }
    public DateTime TimeGenerated { get; }

    protected internal Envelope(T result, int code, string errorMessage, IReadOnlyDictionary<string, string[]> validationErrors)
    {
        Result = result;
        StatusCode = code;
        ErrorMessage = errorMessage;
        ValidationErrors = validationErrors;
        TimeGenerated = DateTime.UtcNow;
    }
}

public class Envelope : Envelope<string>
{
    private Envelope() : base(string.Empty, 200, string.Empty, new Dictionary<string, string[]>()) { }

    private Envelope(string errorMessage, IReadOnlyDictionary<string, string[]> validationErrors) : base(string.Empty, 400, errorMessage, validationErrors) { }

    public static Envelope Success()
    {
        return new Envelope();
    }
    
    public static Envelope<T> Success<T>(T result)
    {
        return new Envelope<T>(result, 200, string.Empty, new Dictionary<string, string[]>());
    }

    public static Envelope Error(string errorMessage)
    {
        return Error(errorMessage, new Dictionary<string, string[]>());
    }
    
    public static Envelope Error(string errorMessage, IReadOnlyDictionary<string, string[]> errors)
    {
        return new Envelope(errorMessage, errors);
    }
}