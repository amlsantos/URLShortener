namespace Domain.Urls;

public class ShortenedUrl
{
    public Guid Id { get; init; }
    public Url LongUrl { get; init; }
    public Url ShortUrl { get; init; }
    public Code Code { get; init; }
    public DateTime CreatedOn { get; init; }
    
    public ShortenedUrl(Url longUrl, Url shortUrl, Code code)
    {
        Id = Guid.NewGuid();
        LongUrl = longUrl;
        ShortUrl = shortUrl;
        Code = code;
        CreatedOn = DateTime.Now;
    }
}