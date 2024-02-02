namespace Presentation.Urls.Contracts;

public record ShortenUrlResponse
{
    public string OriginalUrl { get; set; }
    public string ShortenUrl { get; init; }
}