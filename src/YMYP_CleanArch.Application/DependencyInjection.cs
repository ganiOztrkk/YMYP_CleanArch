using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using YMYP_CleanArch.Domain.Entities;

namespace YMYP_CleanArch.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(
        this IServiceCollection services)
    {
        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssemblies(
                typeof(DependencyInjection).Assembly,
                typeof(AppUser).Assembly);
        });
        
        
        return services;
    }
}