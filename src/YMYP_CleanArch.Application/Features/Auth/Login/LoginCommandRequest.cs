using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YMYP_CleanArch.Application.Features.Auth.Login;
public sealed record LoginCommandRequest(
    string UserName,
    string Password) : IRequest<LoginCommandResponse>;