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

    public async Task<Maybe<ShortenedUrl>> Get(Url url)
    {
        var key = url.AsString();
        
        var isPresent = _memoryCache.TryGetValue(key, out ShortenedUrl? existingUrl);
        if (isPresent)
            return existingUrl;

        var shortenedUrl = await _repository.Get(url);
        _memoryCache.Set(key, shortenedUrl);

        return shortenedUrl;
    }

    public async Task<bool> HasCode(Code code)
    {
        var key = code.AsString();
        
        var isPresent = _memoryCache.TryGetValue(key, out bool result);
        if (isPresent)
            return result;

        var hasCode = await _repository.HasCode(code);
        _memoryCache.Set(key, hasCode);

        return hasCode;
    }

    public async Task<bool> HasUrl(Url url)
    {
        var key = url.AsString();
        
        var isPresent = _memoryCache.TryGetValue(key, out bool result);
        if (isPresent)
            return result;

        var hasUrl = await _repository.HasUrl(url);
        _memoryCache.Set(key, hasUrl);

        return hasUrl;
    }

    public Task AddAsync(ShortenedUrl url) => _repository.AddAsync(url);
}