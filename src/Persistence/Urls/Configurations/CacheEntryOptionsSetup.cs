using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace Persistence.Urls.Configurations;

public class CacheEntryOptionsSetup : IConfigureOptions<CacheEntryOptions>
{
    private readonly IConfiguration _configuration;
    private const string SectionName = CacheEntryOptions.MemoryCacheEntry;

    public CacheEntryOptionsSetup(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void Configure(CacheEntryOptions options)
    {
        _configuration.GetSection(SectionName).Bind(options);
    }
}