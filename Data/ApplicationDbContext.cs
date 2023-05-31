using Microsoft.EntityFrameworkCore;
using SprintathonAPI.Models;

namespace SprintathonAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        
            : base(options){

            }
            public DbSet<Garment> Garments { get; set; }
            //public DbSet<IdNameBase> IdNameBases { get; set; }
            //public DbSet<IdNamePrice> IdNamePrices { get; set; }
            public DbSet<Material> Materials { get; set; }
            public DbSet<Order> Orders { get; set; }
            public DbSet<Service> Services { get; set; }
            public DbSet<GarmentType> GarmentTypes { get; set; }
            public DbSet<User> Users { get; set; }
            public DbSet<Basket> Baskets { get; set; }
        


    }
}
