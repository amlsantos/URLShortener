using Application.Interfaces;
using CSharpFunctionalExtensions;
using Domain.Urls;

namespace Application.UseCases.Urls.Commands.Services;

public class UrlShorteningGenerator : IUrlShorteningGenerator
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICodeGenerator _generator;

    public UrlShorteningGenerator(IUnitOfWork unitOfWork, ICodeGenerator generator)
    {
        _unitOfWork = unitOfWork;
        _generator = generator;
    }

    public async Task<Result<ShortenedUrl>> GenerateAsync(Url url)
    {
        var isUnique = !await _unitOfWork.ShortenedUrls.HasUrl(url);
        if (!isUnique)
            return Result.Failure<ShortenedUrl>(
                $"The url {url.AsString()} is not unique. Please enter a different url:{url.AsString()}");

        var codeOrError = _generator.Generate();
        if (codeOrError.IsFailure)
            return Result.Failure<ShortenedUrl>(codeOrError.Error);
        
        var code = codeOrError.Value;
        
        var shortUrlOrError = Url.Create($"https://short:{80}/{code.AsString()}");
        if (shortUrlOrError.IsFailure)
            return Result.Failure<ShortenedUrl>(shortUrlOrError.Error);
        
        return Result.Success(new ShortenedUrl(url, shortUrlOrError.Value, code));
    }
}