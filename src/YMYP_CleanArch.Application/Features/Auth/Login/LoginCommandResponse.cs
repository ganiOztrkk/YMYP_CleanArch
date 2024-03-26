using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YMYP_CleanArch.Application.Features.Auth.Login;
public class LoginCommandResponse
{
    public string Token { get; set; }= string.Empty;
    public string Message { get; set; }=string.Empty;
}
