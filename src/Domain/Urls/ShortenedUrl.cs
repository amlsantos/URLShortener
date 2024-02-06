using CSharpFunctionalExtensions;

namespace Domain.Urls;

public sealed class ShortenedUrl : Entity<Guid>
{
    public override Guid Id { get; protected set; }
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