using Application.Interfaces;
using CSharpFunctionalExtensions;
using Domain.Urls;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;

namespace Persistence.Urls;

public class CacheUrlRepository : IShortenedUrlRepository
{
    private readonly IShortenedUrlRepository _repository;
    private readonly IMemoryCache _memoryCache;
    private readonly MemoryCacheEntryOptions _options;

    public CacheUrlRepository(IShortenedUrlRepository repository, IMemoryCache memoryCache, IOptions<CacheEntryOptions> options)
    {
        _repository = repository;
        _memoryCache = memoryCache;
        _options = ToMemoryOptions(options.Value);
    }

    private MemoryCacheEntryOptions ToMemoryOptions(CacheEntryOptions options)
    {
        var slidingExpiration = options.SlidingExpiration;
        var absoluteExpiration = options.AbsoluteExpiration;
        
        var isValidPriority = Enum.TryParse(options.CacheItemPriority, out CacheItemPriority priority);
        if (!isValidPriority)
            priority = CacheItemPriority.Normal;

        return new MemoryCacheEntryOptions()
            .SetSlidingExpiration(TimeSpan.FromSeconds(slidingExpiration))
            .SetAbsoluteExpiration(TimeSpan.FromSeconds(absoluteExpiration))
            .SetPriority(priority);
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
        _memoryCache.Set(key, hasUrl, _options);

        return hasUrl;
    }

    public async Task AddAsync(ShortenedUrl url)
    {
        await _repository.AddAsync(url);
    }
}