namespace RobotApocalypse
{
    public interface ISurvivorService
    {
       

            public Task<int> CreateSurvivor(Survivor model);
        public Task<int> CreateSurvivorInventory(SurvivorInventory model);

        public Task<double> InfectedInPercentage();
        public Task<double> UnInfectedInPercentage();
        public Task<IEnumerable<Survivor>> UnInfected();
        public Task<IEnumerable<Survivor>> Infected();
        public Task<ResponseDto<RobotDto>> GetAllRobots();
        public  Task<IEnumerable<RobotDto>> GetRobots();


    }
}
