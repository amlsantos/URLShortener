using System.Text.Json.Serialization;
using Application;
using Application.UseCases.Urls.Commands;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Persistence.Database;
using Presentation.Utils;

namespace Presentation;

public static class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        
        var services = builder.Services;
        var configuration = builder.Configuration;
        
        ConfigureServices(services, configuration);

        var app = builder.Build();
        ConfigureApp(app);
        RunMigrations(app);
        
        app.Run();
    }

    private static void ConfigureServices(IServiceCollection services, IConfigurationManager configuration)
    {
        services.AddCors(options =>
        {
            options.AddPolicy("AllowAllHeaders", builder =>
                {
                    builder.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                }
            );
        });

        services.AddControllers()
            .AddJsonOptions(options => options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        var section = configuration.GetSection(ConnectionStringsOptions.ConnectionStrings);
        services.Configure<ConnectionStringsOptions>(section);
        
        services.AddApplication();
        services.AddPersistence(configuration);
    }

    private static void ConfigureApp(WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseMiddleware<ExceptionMiddleware>();
        app.UseHttpsRedirection();
        app.MapControllers();
    }

    private static void RunMigrations(IHost app)
    {
        using var scope = app.Services.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

        context.Database.Migrate();
    }
}