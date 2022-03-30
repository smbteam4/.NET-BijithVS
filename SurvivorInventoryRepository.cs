using Microsoft.EntityFrameworkCore;

namespace RobotApocalypse
{
    //public class SurvivorInventoryRepository
    //{
    //}
    public class SurvivorInventoryRepository : GenericRepositoryAsync<SurvivorInventory>, ISurvivorInventoryRepository
    {
        private readonly DbSet<SurvivorInventory> _survivorsInventory;

        public SurvivorInventoryRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _survivorsInventory = dbContext.Set<SurvivorInventory>();

        }

    }


    
}
