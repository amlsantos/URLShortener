using Application.Interfaces;
using Application.UseCases.Urls.Commands.Services;
using CSharpFunctionalExtensions;
using Domain.Urls;
using MediatR;

namespace Application.UseCases.Urls.Commands;

public class CreateUrlHandler : IRequestHandler<CreateUrl, Result<ShortenedUrl>>
{
    private readonly UrlShorteningGenerator _generator;
    private readonly IUnitOfWork _unitOfWork;

    public CreateUrlHandler(UrlShorteningGenerator generator, IUnitOfWork unitOfWork)
    {
        _generator = generator;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<ShortenedUrl>> Handle(CreateUrl request, CancellationToken cancellationToken)
    {
        var url = new Url(request.Url);
        
        var urlOrError = await _generator.GenerateAsync(url);
        if (urlOrError.IsFailure)
            return Result.Failure<ShortenedUrl>(urlOrError.Error);

        var shortUrl = urlOrError.Value;
        
        await _unitOfWork.ShortenedUrls.AddAsync(shortUrl);
        
        return Result.Success(shortUrl);
    }
}