using Application.Interfaces;
using Domain.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Common;
using Persistence.Common.Configurations;
using Persistence.Urls;
using Persistence.Urls.Configurations;
using Persistence.Users;

namespace Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services)
    {
        services.AddSingleton<IDataGenerator, DataGenerator>();
        services.ConfigureOptions<ConnectionStringsOptionsSetup>();
        services.AddDbContext<ApplicationDbContext>();
        
        services
            .AddIdentity<User, IdentityRole<Guid>>(options => options.SignIn.RequireConfirmedAccount = true)
            .AddEntityFrameworkStores<ApplicationDbContext>();
        
        services.ConfigureOptions<CacheEntryOptionsSetup>();
        services.AddMemoryCache();

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IShortenedUrlRepository, ShortenedUrlRepository>();
        services.Decorate<IShortenedUrlRepository, CacheUrlRepository>();

        services.AddScoped<IIdentityService, IdentityService>();
        
        return services;
    }
}