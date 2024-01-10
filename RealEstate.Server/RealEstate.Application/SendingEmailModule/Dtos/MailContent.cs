namespace RealEstate.Application.SendingEmailModule.Dtos
{
    public class MailContent
    {
        public string To { get; set; } = null!;            // Địa chỉ gửi đến
        public string Subject { get; set; } = null!;        // Chủ đề (tiêu đề email)
        public string Body { get; set; } = null!;
    }
}
