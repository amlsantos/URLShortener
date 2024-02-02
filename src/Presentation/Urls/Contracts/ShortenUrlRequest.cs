namespace Presentation.Urls.Contracts;

public record ShortenUrlRequest
{
    public string Url { get; init; }
}