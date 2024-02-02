using Application.UseCases.Urls.Services;
using Domain.Urls;
using MediatR;
using Persistence.Database;

namespace Application.UseCases.Urls.Commands;

public class CreateUrlHandler : IRequestHandler<CreateUrl, ShortenedUrl>
{
    private readonly UrlShorteningGenerator _generator;
    private readonly ApplicationDbContext _dbContext;

    public CreateUrlHandler(UrlShorteningGenerator generator, ApplicationDbContext dbContext)
    {
        _generator = generator;
        _dbContext = dbContext;
    }

    public Task<ShortenedUrl> Handle(CreateUrl request, CancellationToken cancellationToken)
    {
        var url = new Url(request.Url);
        var shortenedUrl = _generator.Generate(url);

        _dbContext.ShortenedUrls.Add(shortenedUrl);
        _dbContext.SaveChanges();
        
        return Task.FromResult(shortenedUrl);
    }
}