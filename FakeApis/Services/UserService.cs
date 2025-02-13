using FakeApis.Services.Contracts;
using System.Security.Claims;

namespace FakeApis.Services
{
    public class UserService : IUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string? GetUserId()
        {
            //var userId = _httpContextAccessor.HttpContext?.Items.FirstOrDefault(item => item.Key == "UserId").Value?.ToString();
            var userId = _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
            return userId;
        }
    }
}
