using System.ComponentModel.DataAnnotations;

namespace RealEstate.Application.AuthModule.Dtos
{
    public class RegisterRequestDto
    {
        private string _fullName = null!;
        /// <summary>
        /// Họ tên
        /// </summary>
        [Required(ErrorMessage = "Họ tên không được để trống!")]
        public required string Fullname
        {
            get => _fullName;
            set => value = _fullName.Trim();
        }
        /// <summary>
        /// Số điện thoại
        /// </summary>
        [Required(ErrorMessage = "Số điện thoại không được để trống!")]
        public string PhoneNumber { get; set; } = null!;

        private string _password = null!;
        [Required(ErrorMessage = "Mật khẩu không được để trống!")]
        public string Password
        {
            get => _password;
            set => _password = value.Trim();
        }
        private string _email = null!;
        [Required(ErrorMessage = "Email không được để trống!")]
        [EmailAddress(ErrorMessage = "Email không đúng định dạng!")]
        public string Email
        {
            get => _email;
            set => _email = value.Trim();
        }
    }
}
