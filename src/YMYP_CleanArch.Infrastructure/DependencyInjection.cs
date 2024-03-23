using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using YMYP_CleanArch.Domain.Entities;
using YMYP_CleanArch.Infrastructure.Context;

namespace YMYP_CleanArch.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(opt =>
        {
            opt.UseInMemoryDatabase("MyDb");
        });
        
        services.AddIdentity<AppUser, IdentityRole<Guid>>(opt =>
            {
                opt.Password.RequireUppercase = false;
                opt.Password.RequireLowercase = false;
                opt.Password.RequiredLength = 1;
                opt.Password.RequireDigit = false;
                opt.Password.RequireNonAlphanumeric = false;
            }).AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();
        
        
        return services;
    }
}