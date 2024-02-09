using Application;
using Domain;
using Infrastructure;
using Persistence;
using Presentation.Configurations;
using Presentation.Middlewares;

namespace Presentation;

public static class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        ConfigureServices(builder.Services);

        var app = builder.Build();
        ConfigureApp(app);

        app.Run();
    }

    private static void ConfigureServices(IServiceCollection services)
    {
        services.AddCors();
        services.ConfigureOptions<CorsOptionsSetup>();

        services.AddControllers();
        services.AddEndpointsApiExplorer();
        
        services.AddSwaggerGen();
        services.ConfigureOptions<SwaggerGenOptionsSetup>();
        
        services.AddApplication()
            .AddInfrastructure()
            .AddPersistence()
            .AddDomain();
    }

    private static void ConfigureApp(WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseMiddleware<ExceptionMiddleware>();
        app.UseInfrastructure()
            .UsePersistence();
        app.UseHttpsRedirection();
        app.MapControllers();
    }
}