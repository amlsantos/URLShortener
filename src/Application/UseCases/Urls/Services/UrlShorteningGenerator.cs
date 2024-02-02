using Domain;
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

    public ShortenedUrl GenerateAsync(Url url)
    {
        var code = _generator.Generate();
        
        // validate if is unique
        var isPresent = _context.ShortenedUrls.Any(x => x.Code == code);
        var isUnique = !isPresent;

        if (!isUnique)
            throw new InvalidOperationException($"The code is not unique");

        var shortUrl = new Url($"https://server:{code.AsString()}");

        return new ShortenedUrl(url, shortUrl, code);
    }
}