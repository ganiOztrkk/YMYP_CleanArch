using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace YMYP_CleanArch.WebApi.Abstractions;

[Route("api/[controller]/[action]")]
[ApiController]
public abstract class BaseController  : ControllerBase
{
    public readonly IMediator Mediator;

    protected BaseController(IMediator mediator)
    {
        Mediator = mediator;
    }
}