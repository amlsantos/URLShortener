using CSharpFunctionalExtensions;
using Domain.Urls;

namespace Application.Interfaces;

public interface IShortenedUrlRepository
{
    public Task<Maybe<ShortenedUrl>> GetAsync(Url url);

    public Task<bool> HasCodeAsync(Code code);
    public Task<bool> HasUrlAsync(Url url);
    
    public Task AddAsync(ShortenedUrl url);
}