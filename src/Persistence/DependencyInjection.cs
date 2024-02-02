using Application.Interfaces;
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
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        
        services.AddMemoryCache();
        services.AddDbContext<ApplicationDbContext>();
        
        services.AddScoped<IShortenedUrlRepository, ShortenedUrlRepository>();
        services.Decorate<IShortenedUrlRepository, CachedUrlRepository>();
        
        return services;
    }
};