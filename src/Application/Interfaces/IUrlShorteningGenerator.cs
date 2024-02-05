using CSharpFunctionalExtensions;
using Domain.Urls;

namespace Application.Interfaces;

public interface IUrlShorteningGenerator
{
    Task<Result<ShortenedUrl>> GenerateAsync(Url url);
}