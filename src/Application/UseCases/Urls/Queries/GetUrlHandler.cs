using Domain.Urls;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence.Database;

namespace Application.UseCases.Urls.Queries;

public class GetUrlHandler : IRequestHandler<GetUrl, ShortenedUrl>
{
    private readonly ApplicationDbContext _dbContext;
    public GetUrlHandler(ApplicationDbContext dbContext) => _dbContext = dbContext;

    public Task<ShortenedUrl> Handle(GetUrl request, CancellationToken cancellationToken)
    {
        var url = new Url(request.Url);
        var result = _dbContext.ShortenedUrls.SingleOrDefault(x => x.LongUrl == url);

        if (result is null)
            throw new InvalidOperationException($"There is no url in the database");
        
        return Task.FromResult(result);
    }
}