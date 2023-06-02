namespace SprintathonAPI.Models
{
    public class Business : IdNameBase
    {
        public string Password { get; set; }
        public string Email { get; set; }
    }

    public class BusinessUserDTo
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
    }

    public class BusinessLogInRequest 
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
