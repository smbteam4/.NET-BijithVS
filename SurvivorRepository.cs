

using Microsoft.EntityFrameworkCore;
using RobotApocalypse.Common.DB.Infrastructure.Data;

namespace RobotApocalypse
{
    //public class SurvivorRepository
    //{
    //}

    public class SurvivorRepository : GenericRepositoryAsync<Survivor>, ISurvivorRepository
    {
        private readonly DbSet<Survivor> _survivors;

        public SurvivorRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _survivors = dbContext.Set<Survivor>();

        }

    }
}
