using Microsoft.AspNetCore.Http;
using RealEstate.Shared.Exceptions;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace RealEstate.Shared.Common.Utils
{
    public static class HttpContextExtensions
    {
        public static int GetCurrentUserId(this IHttpContextAccessor httpContextAccessor)
        {
            var claims = httpContextAccessor.HttpContext?.User?.Identity as ClaimsIdentity;
            var claim = claims?.FindFirst(JwtRegisteredClaimNames.Sub) ?? throw new UserFriendlyException("Không tìm thấy id người dùng");
            int userId = int.Parse(claim.Value);
            return userId;
        }
    }
}
