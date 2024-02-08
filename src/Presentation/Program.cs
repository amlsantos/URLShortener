using Application;
using Domain;
using Infrastructure;
using Infrastructure.Users.Configurations;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Persistence.Common;
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
        
        RunMigrations(app);
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
        app.UseInfrastructure();
        app.UseHttpsRedirection();
        
        app.UseAuthentication();
        app.UseAuthorization();
        
        app.MapControllers();
    }

    private static void RunMigrations(IHost app)
    {
        using var scope = app.Services.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        
        context.Database.MigrateAsync();
        DataGenerator.SeedDatabase(context);
    }
}