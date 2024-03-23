using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YMYP_CleanArch.Infrastructure.Context;
using YMYP_CleanArch.WebApi.Abstractions;

namespace YMYP_CleanArch.WebApi.Controllers;


public class AuthController : BaseController
{
    private readonly ApplicationDbContext _context;
    public AuthController(IMediator mediator, ApplicationDbContext context) : base(mediator)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult Test()
    {
        var user = _context.Users.ToList();
        return Ok(user);
    }
}