using Application.Behaviours;
using Application.UseCases.Urls.Commands.Services;
using Domain.Urls;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        var assembly = typeof(DependencyInjection).Assembly;

        services.AddMediatR(configuration => configuration.RegisterServicesFromAssembly(assembly));
        services.AddValidatorsFromAssembly(assembly);
        
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidatorBehavior<,>));

        services.AddScoped<CodeGenerator>();
        services.AddScoped<UrlShorteningGenerator>();
        
        return services;
    }
}