using Domain.Common;

namespace Domain.Urls;

public sealed class ShortenedUrl : Entity
{
    public Url LongUrl { get; init; }
    public Url ShortUrl { get; init; }
    public Code Code { get; init; }
    public DateTime CreatedOn { get; init; }
    
    public ShortenedUrl(Url longUrl, Url shortUrl, Code code)
    {
        LongUrl = longUrl;
        ShortUrl = shortUrl;
        Code = code;
        CreatedOn = DateTime.Now;
    }
}