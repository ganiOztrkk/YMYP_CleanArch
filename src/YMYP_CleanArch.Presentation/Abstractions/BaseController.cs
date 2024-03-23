using Microsoft.AspNetCore.Mvc;

namespace YMYP_CleanArch.Presentation.Abstractions;

[Route("api/[controller]/[action]")]
[ApiController]
public abstract class BaseController : ControllerBase
{
    
}