using MediatR;
using YMYP_CleanArch.WebApi.Abstractions;

namespace YMYP_CleanArch.WebApi.Controllers;


public class AuthController : BaseController
{
    public AuthController(IMediator mediator) : base(mediator)
    {
    }
}