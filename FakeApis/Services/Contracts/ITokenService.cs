using Microsoft.AspNetCore.Identity;

namespace FakeApis.Services.Contracts
{
    public interface ITokenService
    {
        string GenerateRefreshToken();
        Task<string> GenerateToken(IdentityUser user);
    }
}
