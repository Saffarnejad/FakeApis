using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace FakeApis.Middlewares
{
    public class HeaderMiddleware
    {
        private readonly RequestDelegate _next;

        public HeaderMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Headers.ContainsKey("Authorization"))
            {
                var token = context.Request.Headers["Authorization"].ToString().Split(' ').Last();
                var tokenHandler = new JwtSecurityTokenHandler();

                if (tokenHandler.ReadToken(token) is JwtSecurityToken jwtToken)
                {
                    var userId = jwtToken.Claims.First(claim => claim.Type == ClaimTypes.NameIdentifier).Value;
                    context.Items.Add("UserId", userId);
                    var userName = jwtToken.Claims.First(claim => claim.Type == "sub").Value;
                    context.Items.Add("UserName", userName);
                }
            }
            await _next(context);
        }
    }
}
