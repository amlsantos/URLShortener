using Application.Interfaces;
using CSharpFunctionalExtensions;
using Domain.Urls;

namespace Application.UseCases.Urls.Commands.Services;

public class UrlShorteningGenerator
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
        var code = _generator.Generate();

        var isUnique = !await _unitOfWork.ShortenedUrls.HasUrl(url);
        if (!isUnique) 
            return Result.Failure<ShortenedUrl>($"The url {url.AsString()} is not unique. Please enter a different url:{url.AsString()}");

        var shortUrl = new Url($"https://short:{80}/{code.AsString()}");
        return Result.Success(new ShortenedUrl(url, shortUrl, code));
    }
}