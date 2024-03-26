using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using YMYP_CleanArch.Domain.Abstracts;
using YMYP_CleanArch.Domain.Entities;
using YMYP_CleanArch.Domain.Options;

namespace YMYP_CleanArch.Infrastructure.Services;

public class JwtProvider(IOptions<Jwt> jwt) : IJwtProvider //jwt sınıfını ioptions ile çağırıyoruz
{
    public Task<string> CreateTokenAsync(AppUser user)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.UserName ?? string.Empty),
            new Claim("userId", user.Id.ToString()),
            new Claim("username", user.UserName ?? string.Empty)
        };

        var tokenExpires = DateTime.Now.AddMinutes(30);

        var securityToken = new JwtSecurityToken(
            issuer: jwt.Value.Issuer,
            audience: jwt.Value.Audience,
            claims: claims,
            notBefore: DateTime.Now,
            expires: tokenExpires,
            signingCredentials: 
            new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.Value.SecretKey!)), SecurityAlgorithms.HmacSha512));
        
        JwtSecurityTokenHandler handler = new();
        var token = handler.WriteToken(securityToken);

        return Task.FromResult<string>(token);
    }
}