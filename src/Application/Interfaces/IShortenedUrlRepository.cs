using CSharpFunctionalExtensions;
using Domain.Urls;

namespace Application.Interfaces;

public interface IShortenedUrlRepository
{
    public Task<Maybe<ShortenedUrl>> Get(Url url);

    public Task<bool> HasCode(Code code);
    public Task<bool> HasUrl(Url url);
    
    public Task AddAsync(ShortenedUrl url);
}