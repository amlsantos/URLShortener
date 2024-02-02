using Domain.Urls;
using MediatR;

namespace Application.UseCases.Urls.Commands;

public record CreateUrl : IRequest<ShortenedUrl>
{
    public string Url { get; init; }
}