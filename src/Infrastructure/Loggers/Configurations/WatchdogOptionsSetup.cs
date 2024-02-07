using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace Infrastructure.Loggers.Configurations;

public class WatchdogOptionsSetup : IConfigureOptions<WatchdogOptions>
{
    private readonly IConfiguration _configuration;
    private const string SectionName = WatchdogOptions.Watchdog;

    public WatchdogOptionsSetup(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void Configure(WatchdogOptions options)
    {
        _configuration.GetSection(SectionName).Bind(options);
    }
}