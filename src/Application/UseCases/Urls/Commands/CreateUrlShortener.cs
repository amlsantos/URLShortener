using Application.UseCases.Urls.Services;
using Domain;
using Domain.Urls;
using MediatR;

namespace Application.UseCases.Urls.Commands;

public record CreateUrlShortener : IRequest<ShortenedUrl>
{
    public string Url { get; init; }
}

public class CreateUrlShortenerHandler : IRequestHandler<CreateUrlShortener, ShortenedUrl>
{
    private readonly UrlShorteningGenerator _generator;
    public CreateUrlShortenerHandler(UrlShorteningGenerator generator) => _generator = generator;

    public Task<ShortenedUrl> Handle(CreateUrlShortener request, CancellationToken cancellationToken)
    {
        var url = new Url(request.Url);

        var shortenedUrl = _generator.GenerateAsync(url);
        
        // persist
        
        
        return Task.FromResult(shortenedUrl);
    }
}