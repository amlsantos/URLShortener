namespace Presentation.Utils;

public class ErrorDetails
{
    public string Title { get; init; }
    public int StatusCode { get; init; }
    public string Message { get; init; }
    public IReadOnlyDictionary<string, string[]> Errors { get; init; }
}