global using System.Data.SqlTypes;

namespace SprintathonAPI.Models
{
    public class IdNamePrice : IdNameBase
    {
        //public int Id { get; set; }
        //public string Name { get; set; }
        public double Price { get; set; }
    }
}
