using Domain;
using MediatR;

namespace Application.UseCases.Urls.Commands;

public record CreateUrlShortener : IRequest<ShortenedUrl>
{
    public string Url { get; init; }
}

public class CreateUrlShortenerHandler : IRequestHandler<CreateUrlShortener, ShortenedUrl>
{
    public Task<ShortenedUrl> Handle(CreateUrlShortener request, CancellationToken cancellationToken)
    {
        var result = new ShortenedUrl();
        return Task.FromResult(result);
    }
}