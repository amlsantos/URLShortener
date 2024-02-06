using Application.Interfaces;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Database;
using Persistence.Urls;

namespace Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfigurationManager manager)
    {
        services.Configure<ConnectionStringsOptions>(manager.GetSection(ConnectionStringsOptions.ConnectionStrings));
        services.AddDbContext<ApplicationDbContext>();

        services.Configure<CacheEntryOptions>(manager.GetSection(CacheEntryOptions.MemoryCacheEntry));
        services.AddMemoryCache();

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IShortenedUrlRepository, ShortenedUrlRepository>();
        services.Decorate<IShortenedUrlRepository, CacheUrlRepository>();
        
        return services;
    }
};