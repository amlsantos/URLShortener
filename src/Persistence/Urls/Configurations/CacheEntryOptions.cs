using Microsoft.Extensions.Caching.Memory;

namespace Persistence.Urls.Configurations;

public class CacheEntryOptions
{
    public const string MemoryCacheEntry = nameof(MemoryCacheEntry);
    public int SlidingExpiration { get; set; }
    public int AbsoluteExpiration { get; set;}
    public string CachePriority { get; set;}

    public MemoryCacheEntryOptions ToMemoryOptions()
    {
        var isValidPriority = Enum.TryParse(CachePriority, out CacheItemPriority priority);
        if (!isValidPriority)
            priority = CacheItemPriority.Normal;

        return new MemoryCacheEntryOptions()
            .SetSlidingExpiration(TimeSpan.FromSeconds(SlidingExpiration))
            .SetAbsoluteExpiration(TimeSpan.FromSeconds(AbsoluteExpiration))
            .SetPriority(priority);
    }
}