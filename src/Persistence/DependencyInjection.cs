using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Database;

namespace Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfigurationManager manager)
    {
        var section = manager.GetSection(ConnectionStringsOptions.ConnectionStrings);

        // services.Configure<ConnectionStringsOptions>(section);
        
        services.AddDbContext<ApplicationDbContext>();
        
        return services;
    }
};