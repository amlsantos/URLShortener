using Application.Interfaces;
using CSharpFunctionalExtensions;
using Domain.Urls;
using MediatR;

namespace Application.UseCases.Urls.Commands;

public class CreateUrlHandler : IRequestHandler<CreateUrl, Result<ShortenedUrl>>
{
    private readonly IUrlShorteningGenerator _generator;
    private readonly IUnitOfWork _unitOfWork;

    public CreateUrlHandler(IUrlShorteningGenerator generator, IUnitOfWork unitOfWork)
    {
        _generator = generator;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<ShortenedUrl>> Handle(CreateUrl request, CancellationToken cancellationToken)
    {
        var urlOrError = Url.Create(request.Url);
        if (urlOrError.IsFailure)
            return Result.Failure<ShortenedUrl>(urlOrError.Error);

        var url = urlOrError.Value;
        var shortUrlOrError = await _generator.GenerateAsync(url);
        if (shortUrlOrError.IsFailure)
            return Result.Failure<ShortenedUrl>(shortUrlOrError.Error);

        var shortUrl = shortUrlOrError.Value;
        
        await _unitOfWork.ShortUrls.AddAsync(shortUrl);
        
        return Result.Success(shortUrl);
    }
}