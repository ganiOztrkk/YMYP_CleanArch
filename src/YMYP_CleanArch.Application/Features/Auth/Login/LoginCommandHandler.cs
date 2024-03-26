using MediatR;
using Microsoft.AspNetCore.Identity;
using YMYP_CleanArch.Domain.Abstracts;
using YMYP_CleanArch.Domain.Entities;

namespace YMYP_CleanArch.Application.Features.Auth.Login;
internal sealed class LoginCommandHandler(
    UserManager<AppUser> userManager,
    IJwtProvider jwtProvider) : IRequestHandler<LoginCommandRequest, LoginCommandResponse>
{
    public async Task<LoginCommandResponse> Handle(LoginCommandRequest request, CancellationToken cancellationToken)
    {
        AppUser? appUser = await userManager.FindByNameAsync(request.UserName);

        if (appUser is null)
        {
            throw new ArgumentException("Kullanıcı adı bulunamadı!");
        }

        bool isPasswordTrue = await userManager.CheckPasswordAsync(appUser, request.Password);

        if (!isPasswordTrue)
        {
            throw new ArgumentException("Şifre hatalı!");
        }

        var token = await jwtProvider.CreateTokenAsync(appUser);
        
        return new LoginCommandResponse
        {
            Token=token,
            Message="Kullanıcı Girişi Başarılı"
        };
    }
}

