using RealEstate.Application.AuthModule.Dtos;

namespace RealEstate.Application.AuthModule.Abstracts
{
    public interface IAuthService
    {
        /// <summary>
        /// Đăng nhập
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        TokenDto Login(LoginRequestDto input);
        /// <summary>
        /// Đăng kí
        /// </summary>
        /// <param name="input"></param>
        void Register(RegisterRequestDto input);
        public TokenDto RefreshToken(TokenDto input);
    }
}
