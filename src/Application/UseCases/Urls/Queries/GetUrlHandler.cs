using Application.Interfaces;
using Domain.Urls;
using MediatR;

namespace Application.UseCases.Urls.Queries;

public class GetUrlHandler : IRequestHandler<GetUrl, ShortenedUrl>
{
    private readonly IUnitOfWork _unitOfWork;
    public GetUrlHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

    public Task<ShortenedUrl> Handle(GetUrl request, CancellationToken cancellationToken)
    {
        var url = new Url(request.Url);
        var result = _unitOfWork.ShortenedUrls.Get(url);

        if (result is null)
            throw new InvalidOperationException($"There is no url in the database");
        
        return Task.FromResult(result);
    }
}