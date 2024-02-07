using Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Common;
using Persistence.Common.Configurations;
using Persistence.Urls;
using Persistence.Urls.Configurations;

namespace Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services)
    {
        services.ConfigureOptions<ConnectionStringsOptionsSetup>();
        services.AddDbContext<ApplicationDbContext>();
        
        services.ConfigureOptions<CacheEntryOptionsSetup>();
        services.AddMemoryCache();

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IShortenedUrlRepository, ShortenedUrlRepository>();
        services.Decorate<IShortenedUrlRepository, CacheUrlRepository>();
        
        return services;
    }
}