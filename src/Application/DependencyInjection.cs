using Application.Behaviours;
using Application.Interfaces;
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
        
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));

        services.AddScoped<ICodeGenerator, CodeGenerator>();
        services.AddScoped<IUrlShorteningGenerator, UrlShorteningGenerator>();
        
        return services;
    }
}