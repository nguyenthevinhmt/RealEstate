namespace RealEstate.Shared.Options
{
    public class JwtSettings
    {
        public string Key { get; set; } = null!;
        public string ValidIssuer { get; set; } = null!;
        public string ValidAudience { get; set; } = null!;
        public string ExpiredTime { get; set; } = null!;
    }
}
