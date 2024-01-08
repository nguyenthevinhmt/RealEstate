using System.ComponentModel.DataAnnotations;

namespace RealEstate.Domain.Entities
{
    public class User
    {
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
        public int UserType { get; set; }
        public bool IsConfirm { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
