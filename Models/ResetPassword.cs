namespace SprintathonAPI.Models
{
    public class RestPassword
    {
        public int UserId { get; set; }
        public string OTP { get; set; }
        public string Email { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmPassword { get; set; }
    }
    
    
}
