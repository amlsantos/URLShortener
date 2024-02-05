using Application.Interfaces;
using CSharpFunctionalExtensions;
using Domain.Urls;
using MediatR;

namespace Application.UseCases.Urls.Queries;

public class GetUrlHandler : IRequestHandler<GetUrl, Result<ShortenedUrl>>
{
    private readonly IUnitOfWork _unitOfWork;
    public GetUrlHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

    public Task<Result<ShortenedUrl>> Handle(GetUrl request, CancellationToken cancellationToken)
    {
        var url = new Url(request.ShortUrl);
        
        var urlOrNothing = _unitOfWork.ShortenedUrls.Get(url);
        if (urlOrNothing.HasNoValue)
        {
            var failure = Result.Failure<ShortenedUrl>($"There is no url in the database: {request.ShortUrl}");
            return Task.FromResult(failure);
        }

        var shortenedUrl = urlOrNothing.Value;
        return Task.FromResult(Result.Success(shortenedUrl));
    }
}