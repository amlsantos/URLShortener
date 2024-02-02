namespace Domain;

public class ShortenedUrl
{
    public Guid Id { get; init; }
    public Url LongUrl { get; init; }
    public Url ShortUrl { get; init; }
    public DateTime CreatedOn { get; init; }
    
    public ShortenedUrl(Url longUrl, Url shortUrl)
    {
        Id = Guid.NewGuid();
        LongUrl = longUrl;
        ShortUrl = shortUrl;
        CreatedOn = DateTime.Now;
    }
}