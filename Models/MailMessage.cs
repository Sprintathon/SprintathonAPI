namespace SprintathonAPI.Models
{
    public class MailMessage : IdNameBase
    {
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
    }
}