using Microsoft.AspNetCore.Identity;
using YMYP_CleanArch.Domain.Entities;
using YMYP_CleanArch.Infrastructure.Context;

namespace YMYP_CleanArch.WebApi.Middlewares;

public static class CreateFirstUserMiddleware
{
    public static void CreateFirstUser(WebApplication app)
    {
        using var scoped = app.Services.CreateScope();
        var userManager = scoped.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
        var context = scoped.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    }
}