namespace RealEstate.Application.UserModule.Dtos
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Fullname { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PhoneNumber {  get; set; } = null!;
        public string? AvatarUrl {  get; set; }
    }
}
