namespace RealEstate.Application.AuthModule.Dtos
{
    public class LoginRequestDto
    {
        private string _username { get; set; } = null!;
        /// <summary>
        /// Tên người dùng
        /// </summary>
        public string Username
        {
            get => _username;
            set => _username = value.Trim();
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
