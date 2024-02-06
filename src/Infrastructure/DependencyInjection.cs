using Application.Interfaces;
using Infrastructure.Behaviours;
using Infrastructure.Loggers;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WatchDog;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfigurationManager manager)
    {
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
        services.AddScoped<IConsoleLogger, ConsoleLogger>();
        services.Decorate<IConsoleLogger, WatchDogLogger>();
        
        services.Configure<WatchdogOptions>(manager.GetSection(WatchdogOptions.Watchdog));
        services.AddWatchDogServices();
        
        return services;
    }

    public static WebApplication UseInfrastructure(this WebApplication app)
    {
        app.UseWatchDogExceptionLogger();
        
        var watchDogOptions = app.Configuration.GetSection(WatchdogOptions.Watchdog).Get<WatchdogOptions>();
        if (watchDogOptions is null)
            throw new InvalidOperationException($"Invalid WatchDog configuration. Please check your AppSetting.Json");

        app.UseWatchDog(options =>
        {
            options.WatchPageUsername = watchDogOptions.PageUsername;
            options.WatchPagePassword = watchDogOptions.PagePassword;
        });
        
        return app;
    }
}