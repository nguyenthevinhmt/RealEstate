using Microsoft.AspNetCore.Mvc;
using RealEstate.Application.AuthModule.Abstracts;
using RealEstate.Application.AuthModule.Dtos;

namespace RealEstate.API.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        /// <summary>
        /// Đăng nhập
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequestDto input)
        {
            try
            {
                return Ok(_authService.Login(input));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
