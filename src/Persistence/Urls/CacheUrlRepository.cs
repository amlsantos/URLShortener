using Application.Interfaces;
using CSharpFunctionalExtensions;
using Domain.Urls;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;

namespace Persistence.Urls;

public class CacheUrlRepository : IShortenedUrlRepository
{
    private readonly IMemoryCache _memoryCache;
    private readonly MemoryCacheEntryOptions _options;
    private readonly IShortenedUrlRepository _repository;

    public CacheUrlRepository(IMemoryCache memoryCache, IOptions<CacheEntryOptions> options, IShortenedUrlRepository repository)
    {
        _memoryCache = memoryCache;
        _options = options.Value.ToMemoryOptions();
        _repository = repository;
    }

    public async Task<Maybe<ShortenedUrl>> GetAsync(Url url)
    {
        var key = url.Value();

        var isPresent = _memoryCache.TryGetValue(key, out Maybe<ShortenedUrl> existingUrl);
        if (isPresent)
            return existingUrl;

        var shortenedUrl = await _repository.GetAsync(url);
        _memoryCache.Set(key, shortenedUrl, _options);

        return shortenedUrl;
    }

    public async Task<bool> HasCodeAsync(Code code)
    {
        var key = code.Value();

        var isPresent = _memoryCache.TryGetValue(key, out bool result);
        if (isPresent)
            return result;

        var hasCode = await _repository.HasCodeAsync(code);
        _memoryCache.Set(key, hasCode, _options);

        return hasCode;
    }

    public async Task<bool> HasUrlAsync(Url url)
    {
        var key = url.Value();

        var isPresent = _memoryCache.TryGetValue(key, out bool result);
        if (isPresent)
            return result;

        var hasUrl = await _repository.HasUrlAsync(url);
        // _memoryCache.Set(key, hasUrl, _options);

        return hasUrl;
    }

    public async Task AddAsync(ShortenedUrl url)
    {
        await _repository.AddAsync(url);
    }
}