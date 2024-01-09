using Microsoft.EntityFrameworkCore;
using RealEstate.Shared.Constants;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace RealEstate.Domain.Entities
{
    [Table(nameof(User), Schema = "dbo")]
    [Index(nameof(Email), nameof(Status), nameof(UserType), Name = $"IX_{nameof(User)}")]
    public class User
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50)]
        public string Fullname { get; set; } = null!;
        [MaxLength(50)]
        public string Email { get; set; } = null!;
        [MaxLength(32)]
        public string Password { get; set; } = null!;
        [MaxLength(12)]
        public string PhoneNumber { get; set; } = null!;
        [MaxLength(512)]
        public string? RefreshToken { get; set; }
        public DateTime RefreshTokenExpiryTime { get; set; }
        /// <summary>
        /// Đường dẫn link ảnh
        /// </summary>
        [MaxLength(512)]
        public string? AvatarUrl { get; set; }
        public int UserType { get; set; }
        public bool IsConfirm { get; set; }
        /// <summary>
        /// Trạng thái tài khoản user
        /// <see cref="UserStatus"/>
        /// </summary>
        public int Status { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
