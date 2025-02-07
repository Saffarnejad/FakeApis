using Microsoft.AspNetCore.Identity;

namespace FakeApis.Services.Contracts
{
    public interface ITokenService
    {
        string GenerateToken(IdentityUser user);
    }
}
