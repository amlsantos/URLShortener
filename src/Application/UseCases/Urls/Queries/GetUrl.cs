using CSharpFunctionalExtensions;
using Domain.Urls;
using MediatR;

namespace Application.UseCases.Urls.Queries;

public record GetUrl : IRequest<Result<ShortenedUrl>>
{
    public string ShortUrl { get; init; }
}