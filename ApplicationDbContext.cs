using Microsoft.EntityFrameworkCore;

namespace RobotApocalypse
{
    //public class ApplicationDbContext
    //{
    //}

    
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :
            base(options)
        {

        }

        public DbSet<Survivor> Survivors { get; set; }
        public DbSet<SurvivorInventory> SurvivorInventory { get; set; } 
    }
}

