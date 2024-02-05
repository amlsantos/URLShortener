using Domain.Urls;
using Microsoft.Extensions.DependencyInjection;

namespace Domain;

public static class DependencyInjection
{
    public static IServiceCollection AddDomain(this IServiceCollection services)
    {
        services.AddScoped<ICodeGenerator, CodeGenerator>();
        
        return services;
    }
}