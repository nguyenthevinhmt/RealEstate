namespace RealEstate.Application.AuthModule.Dtos
{
    public class LoginRequestDto
    {
        private string _email { get; set; } = null!;
        /// <summary>
        /// Số điện thoại đăng kí
        /// </summary>
        public string Email
        {
            get => _email;
            set => _email = value.Trim();
        }
        private string _password { get; set; } = null!;
        /// <summary>
        /// Mật khẩu
        /// </summary>
        public string Password
        {
            get => _password;
            set => _password = value.Trim();
        }
    }
}
