using Application.Interfaces;
using Domain.Urls;

namespace Application.UseCases.Urls.Commands.Services;

public class UrlShorteningGenerator
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly CodeGenerator _generator;

    public UrlShorteningGenerator(IUnitOfWork unitOfWork, CodeGenerator generator)
    {
        _unitOfWork = unitOfWork;
        _generator = generator;
    }

    public ShortenedUrl Generate(Url url)
    {
        var code = _generator.Generate();
        
        var isPresent = _unitOfWork.ShortenedUrls.HasCode(code) || _unitOfWork.ShortenedUrls.HasUrl(url);
        var isUnique = !isPresent;

        if (!isUnique)
            throw new InvalidOperationException($"The url {url.AsString()} is not unique. Please enter a different url");

        var shortUrl = new Url($"https://short:{80}/{code.AsString()}");

        return new ShortenedUrl(url, shortUrl, code);
    }
}