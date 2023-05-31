using SprintathonAPI.Enums;

namespace SprintathonAPI.Models { 

    public class User: IdNameBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Location { get; set; }
        public string PhoneNumber { get; set; }
        public Role Role { get; set; }
    }

    public class UserLogInDTo
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class CreateUserDto : User
    {
        public readonly int Id = 0;
        public string Name { get=> $"{FirstName} {LastName}";}
    }
}