using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using RealEstate.Application.UserModule.Abstracts;
using RealEstate.Application.UserModule.Dtos;
using RealEstate.Infrastructure.Persistence;
using RealEstate.Shared.Common.Utils;

namespace RealEstate.Application.UserModule.Implements
{
    public class UserService : IUserService
    {
        private readonly ILogger _logger;
        private readonly IHttpContextAccessor _httpContext;
        private readonly ApplicationDbContext _context;
        public UserService(ILogger<UserService> logger, IHttpContextAccessor httpContext, ApplicationDbContext context) {
            _logger = logger;
            _httpContext = httpContext;
            _context = context;
        }
        public UserDto FindCurrentUserInfo()
        {
            var currentUserId = _httpContext.GetCurrentUserId();
            _logger.LogInformation("");
            return new();
        }
    }
}
