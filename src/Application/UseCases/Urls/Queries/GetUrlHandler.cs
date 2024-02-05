using Application.Interfaces;
using CSharpFunctionalExtensions;
using Domain.Urls;
using MediatR;

namespace Application.UseCases.Urls.Queries;

public class GetUrlHandler : IRequestHandler<GetUrl, Result<ShortenedUrl>>
{
    private readonly IUnitOfWork _unitOfWork;
    public GetUrlHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

    public async Task<Result<ShortenedUrl>> Handle(GetUrl request, CancellationToken cancellationToken)
    {
        var urlOrError = Url.Create(request.ShortUrl);
        if (urlOrError.IsFailure)
            return Result.Failure<ShortenedUrl>(urlOrError.Error);

        var url = urlOrError.Value;
        var urlOrNothing = await _unitOfWork.ShortenedUrls.Get(url);
        
        if (urlOrNothing.HasNoValue)
            return Result.Failure<ShortenedUrl>($"There is no url in the database: {request.ShortUrl}");

        return Result.Success(urlOrNothing.Value);
    }
}