using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace Persistence.Common.Configurations;

public class ConnectionStringsOptionsSetup : IConfigureOptions<ConnectionStringsOptions>
{
    private readonly IConfiguration _configuration;
    private const string SectionName = ConnectionStringsOptions.ConnectionStrings;

    public ConnectionStringsOptionsSetup(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void Configure(ConnectionStringsOptions options)
    {
        _configuration.GetSection(SectionName).Bind(options);
    }
}