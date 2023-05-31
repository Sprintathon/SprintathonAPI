namespace SprintathonAPI.Models
{
    //Order Model 
    public class Order
    {
        public int Id { get; set; }
        public int UserId{ get; set; }
        public string GarmentId { get; set; }
        public string ServiceId { get; set;}
    }
}
