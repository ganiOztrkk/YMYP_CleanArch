using YMYP_CleanArch.Domain.Entities;

namespace YMYP_CleanArch.Domain.Abstracts;

public interface IJwtProvider
{
    Task<string> CreateTokenAsync(AppUser user);
}