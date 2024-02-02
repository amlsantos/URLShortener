using Domain.Urls;
using MediatR;

namespace Application.UseCases.Urls.Queries;

public record GetUrl : IRequest<ShortenedUrl>
{
    public string ShortUrl { get; init; }
}