using MediatR;
using Microsoft.AspNetCore.Mvc;
using NuGet.Common;
using NuGet.Protocol.Plugins;
using YMYP_CleanArch.Application.Features.Auth.Login;
using YMYP_CleanArch.Infrastructure.Context;
using YMYP_CleanArch.WebApi.Abstractions;

namespace YMYP_CleanArch.WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class AuthController(IMediator mediator, ApplicationDbContext context) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Login(LoginCommandRequest request, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(request, cancellationToken);
        //var loginResponse = new LoginCommandResponse
        //{
        //    Message = response.Message,
        //    Token = response.Token
        //};
        return Ok(response);
    }
    [HttpGet]
    public IActionResult Test()
    {
        var user = context.Users.ToList();
        return Ok(user);
    }
}

