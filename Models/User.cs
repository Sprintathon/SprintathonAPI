namespace SprintathonAPI.Models

public class User: IdNameBase
{
    public string firstName { get; set; }
    public string lastName { get; set; }
    public string email { get; set; }
    public string password { get; set; }
    public string location { get; set; }
    public string phoneNumber { get; set; }

       
}