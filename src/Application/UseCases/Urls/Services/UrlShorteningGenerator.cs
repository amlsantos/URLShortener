using Domain.Urls;
using Persistence.Database;

namespace Application.UseCases.Urls.Services;

public class UrlShorteningGenerator
{
    private readonly ApplicationDbContext _context;
    private readonly CodeGenerator _generator;

    public UrlShorteningGenerator(ApplicationDbContext context, CodeGenerator generator)
    {
        _context = context;
        _generator = generator;
    }

    public ShortenedUrl Generate(Url url)
    {
        var code = _generator.Generate();
        
        var isPresent = _context.ShortenedUrls.Any(x => x.Code == code || x.LongUrl == url);
        var isUnique = !isPresent;

        if (!isUnique)
            throw new InvalidOperationException($"The url {url.AsString()} is not unique. Please enter a different url");

        var shortUrl = new Url($"https://server:{code.AsString()}");

        return new ShortenedUrl(url, shortUrl, code);
    }
}