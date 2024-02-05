using Application.Interfaces;
using CSharpFunctionalExtensions;
using Domain.Urls;
using Microsoft.Extensions.Caching.Memory;

namespace Persistence.Urls;

public class CachedUrlRepository : IShortenedUrlRepository
{
    private readonly IShortenedUrlRepository _repository;
    private readonly IMemoryCache _memoryCache;

    public CachedUrlRepository(IShortenedUrlRepository repository, IMemoryCache memoryCache)
    {
        _repository = repository;
        _memoryCache = memoryCache;
    }

    public Maybe<ShortenedUrl> Get(Url url)
    {
        var key = url.AsString();
        
        var isPresent = _memoryCache.TryGetValue(key, out ShortenedUrl? existingUrl);
        if (isPresent)
            return existingUrl;

        var shortenedUrl = _repository.Get(url);
        _memoryCache.Set(key, shortenedUrl);

        return shortenedUrl;
    }

    public bool HasCode(Code code)
    {
        var key = code.AsString();
        
        var isPresent = _memoryCache.TryGetValue(key, out bool result);
        if (isPresent)
            return result;

        var hasCode = _repository.HasCode(code);
        _memoryCache.Set(key, hasCode);

        return hasCode;
    }

    public bool HasUrl(Url url)
    {
        var key = url.AsString();
        
        var isPresent = _memoryCache.TryGetValue(key, out bool result);
        if (isPresent)
            return result;

        var hasUrl = _repository.HasUrl(url);
        _memoryCache.Set(key, hasUrl);

        return hasUrl;
    }

    public void Add(ShortenedUrl url) => _repository.Add(url);
}