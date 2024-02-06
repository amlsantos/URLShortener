namespace Persistence.Urls;

public class CacheEntryOptions
{
    public const string MemoryCacheEntry = nameof(MemoryCacheEntry);
    public int SlidingExpiration { get; set; }
    public int AbsoluteExpiration { get; set; }
    public string CacheItemPriority { get; set; }
}