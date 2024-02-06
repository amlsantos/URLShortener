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

    public async Task<Maybe<ShortenedUrl>> GetAsync(Url url)
    {
        var key = url.Value();
        
        var isPresent = _memoryCache.TryGetValue(key, out Maybe<ShortenedUrl> existingUrl);
        if (isPresent)
            return existingUrl;

        var shortenedUrl = await _repository.GetAsync(url);
        _memoryCache.Set(key, shortenedUrl);

        return shortenedUrl;
    }

    public async Task<bool> HasCodeAsync(Code code)
    {
        var key = code.Value();
        
        var isPresent = _memoryCache.TryGetValue(key, out bool result);
        if (isPresent)
            return result;

        var hasCode = await _repository.HasCodeAsync(code);
        _memoryCache.Set(key, hasCode);

        return hasCode;
    }

    public async Task<bool> HasUrlAsync(Url url)
    {
        var key = url.Value();
        
        var isPresent = _memoryCache.TryGetValue(key, out bool result);
        if (isPresent)
            return result;

        var hasUrl = await _repository.HasUrlAsync(url);
        _memoryCache.Set(key, hasUrl);

        return hasUrl;
    }

    public async Task AddAsync(ShortenedUrl url)
    {
        await _repository.AddAsync(url);
    }
}