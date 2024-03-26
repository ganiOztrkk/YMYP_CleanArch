using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using YMYP_CleanArch.Domain.Entities;
using YMYP_CleanArch.Domain.Options;
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
        
        services.Configure<Jwt>(configuration.GetSection("Jwt"));
        var serviceProvider = services.BuildServiceProvider();
        var jwtConfiguration = serviceProvider.GetRequiredService<IOptions<Jwt>>().Value;

        services
            .AddAuthentication()
            .AddJwtBearer(cfr =>
            {
                cfr.TokenValidationParameters = new()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateIssuerSigningKey =
                        true,
                    ValidateLifetime = true,
                    ValidIssuer = jwtConfiguration.Issuer,
                    ValidAudience = jwtConfiguration.Audience, 
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfiguration.SecretKey!))
                };
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