using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using YMYP_CleanArch.Domain.Entities;

namespace YMYP_CleanArch.Application.Features.Auth.Login;
internal sealed class LoginCommandHandler(
    UserManager<AppUser> userManager) : IRequestHandler<LoginCommandRequest, LoginCommandResponse>
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

        return new LoginCommandResponse
        {
            Token="token",
            Message="Kullanıcı Girişi Başarılı"
        };
    }
}

