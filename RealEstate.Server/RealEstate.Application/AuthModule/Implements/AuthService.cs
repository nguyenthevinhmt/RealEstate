using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using RealEstate.Application.AuthModule.Abstracts;
using RealEstate.Application.AuthModule.Dtos;
using RealEstate.Infrastructure.Persistence;
using RealEstate.Shared.Common.Utils;
using RealEstate.Shared.Constants;
using RealEstate.Shared.Exceptions;
using RealEstate.Shared.Options;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Text;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace RealEstate.Application.AuthModule.Implements
{
    public class AuthService : IAuthService
    {
        private readonly ApplicationDbContext _context;
        private readonly JwtSettings _jwtSetting;
        private readonly IHttpContextAccessor _httpContext;
        private readonly ILogger _logger;
        public AuthService(ApplicationDbContext context, IOptions<JwtSettings> options, IHttpContextAccessor httpContext, ILogger<AuthService> logger)
        {
            _context = context;
            _jwtSetting = options.Value;
            _httpContext = httpContext;
            _logger = logger;
        }
        public TokenDto Login(LoginRequestDto input)
        {
            var user = _context.Users.FirstOrDefault(x => x.Username == input.Username);
            if (user == null)
            {
                throw new UserFriendlyException($"Tài khoản không tồn tại!");
            }
            if (!PasswordHasher.VerifyPassword(input.Password, user.Password))
            {
                throw new UserFriendlyException("Sai mật khẩu");
            }
            var newAccessToken = CreateJwt(input);
            var newRefreshToken = CreateRefreshToken();
            user.RefreshToken = newRefreshToken;
            user.RefreshTokenExpiryTime = DateTime.Now.AddSeconds(15);
            _context.SaveChangesAsync();
            return new TokenDto
            {
                AccessToken = newAccessToken,
                RefreshToken = newRefreshToken
            };
        }

        public void Register(RegisterRequestDto input)
        {
            var checkMailExist = _context.Users.FirstOrDefault(x => x.Email == input.Email) ?? throw new UserFriendlyException("Email đã tồn tại");
            var checkUsernameExist = _context.Users.FirstOrDefault(x => x.Username == input.Username) ?? throw new UserFriendlyException("Tên người dùng đã tồn tại");
            if (input.Password.Length < 6)
            {
                throw new UserFriendlyException("Mật khẩu phải dài hơn 6 kí tự");
            }
            if (!(Regex.IsMatch(input.Password, "[a-z]") && Regex.IsMatch(input.Password, "[A-Z]") && Regex.IsMatch(input.Password, "[0-9]")))
            {
                throw new UserFriendlyException("Mật khẩu phải thuộc kiểu số và chữ");
            }
            if (!Regex.IsMatch(input.Password, "[<,>,@,!,#,$,%,^,&,*,(,),_,+,\\[,\\],{,},?,:,;,|,',\\,.,/,~,`,-,=]"))
                throw new UserFriendlyException("Mật khẩu phải chứa ít nhất 1 kí tự đặc biệt");

            _context.Users.Add(new Domain.Entities.User
            {
                Email = input.Email,
                Password = PasswordHasher.HashPassword(input.Password),
                UserType = UserType.CUSTOMER,
            });
            _context.SaveChanges();
        }
        public TokenDto RefreshToken(TokenDto input)
        {
            if (input is null)
                throw new UserFriendlyException("Invalid Client Request");
            string accessToken = input.AccessToken;
            string refreshToken = input.RefreshToken;
            var principal = GetPrincipleFromExpiredToken(accessToken);
            var username = principal?.Identity?.Name;

            var user = _context.Users.FirstOrDefault(u => u.Username == username);
            if (user is null || user.RefreshToken != refreshToken || user.RefreshTokenExpiryTime <= DateTime.Now)
            {
                Revoke();
                throw new UserFriendlyException("Invalid Request");
            }
            var newAccessToken = CreateJwt(new LoginRequestDto { Username = user.Username, Password = user.Password });
            var newRefreshToken = CreateRefreshToken();
            user.RefreshToken = newRefreshToken;
            _context.SaveChangesAsync();
            return new TokenDto()
            {
                AccessToken = newAccessToken,
                RefreshToken = newRefreshToken,
            };
        }
        private string CreateJwt(LoginRequestDto user)
        {
            var jwtToken = new JwtSecurityTokenHandler();
            var findUser = _context.Users.FirstOrDefault(u => u.Username == user.Username)
                        ?? throw new UserFriendlyException("Tài khoản không tồn tại");

            var key = Encoding.ASCII.GetBytes(_jwtSetting.Key);
            var claims = new List<Claim> {
                new Claim(CustomClaimTypes.UserId, findUser.Id.ToString()),
                new Claim(ClaimTypes.Name, findUser.Username),
                new Claim(CustomClaimTypes.Email, findUser.Email),
                new Claim(CustomClaimTypes.Phone, findUser.PhoneNumber),
                new Claim(JwtRegisteredClaimNames.Sub, findUser.Id.ToString()),
                new Claim(CustomClaimTypes.UserType, findUser.UserType.ToString())
            };
            var credentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _jwtSetting.ValidIssuer,
                audience: _jwtSetting.ValidAudience,
                expires: DateTime.Now.AddSeconds(5),
                claims: claims,
                signingCredentials: credentials
            );
            return jwtToken.WriteToken(token);
        }
        private string CreateRefreshToken()
        {
            var tokenBytes = RandomNumberGenerator.GetBytes(64);
            var refreshToken = Convert.ToBase64String(tokenBytes);
            var tokenInUser = _context.Users.Any(a => a.RefreshToken == refreshToken);
            if (tokenInUser)
            {
                return CreateRefreshToken();
            }
            return refreshToken;
        }
        private ClaimsPrincipal GetPrincipleFromExpiredToken(string token)
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = false,
                ValidateIssuer = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_jwtSetting.Key)),
                ValidateLifetime = false
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken securityToken;
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out securityToken);
            var jwtSecurityToken = securityToken as JwtSecurityToken;
            if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
            {
                throw new UserFriendlyException("Hết hạn đăng nhập, vui lòng đăng nhập lại");
            }
            return principal;
        }
        /// <summary>
        /// Xóa refresh token khi hết hạn
        /// </summary>
        /// <exception cref="UserFriendlyException"></exception>
        private void Revoke()
        {
            var userId = _httpContext.GetCurrentUserId();
            _logger.LogInformation($"userId: {userId}");
            var user = _context.Users.FirstOrDefault(c => c.Id == userId) ?? throw new UserFriendlyException("Không tìm thấy người dùng");
            user.RefreshToken = "";
            user.RefreshTokenExpiryTime = null;
            _context.SaveChanges();
        }
    }
}
