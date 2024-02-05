using Application.Interfaces;
using Application.UseCases.Urls.Commands.Services;
using Domain.Urls;
using MediatR;

namespace Application.UseCases.Urls.Commands;

public class CreateUrlHandler : IRequestHandler<CreateUrl, ShortenedUrl>
{
    private readonly UrlShorteningGenerator _generator;
    private readonly IUnitOfWork _unitOfWork;

    public CreateUrlHandler(UrlShorteningGenerator generator, IUnitOfWork unitOfWork)
    {
        _generator = generator;
        _unitOfWork = unitOfWork;
    }

    public Task<ShortenedUrl> Handle(CreateUrl request, CancellationToken cancellationToken)
    {
        var url = new Url(request.Url);
        var shortenedUrl = _generator.Generate(url);
        
        _unitOfWork.ShortenedUrls.Add(shortenedUrl);
        _unitOfWork.SaveChanges();
        
        return Task.FromResult(shortenedUrl);
    }
}