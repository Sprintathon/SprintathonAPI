namespace SprintathonAPI.Models { 

    public class User: IdNameBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Location { get; set; }
        public string PhoneNumber { get; set; }

       
    }
}