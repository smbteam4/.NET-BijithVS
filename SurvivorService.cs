using Newtonsoft.Json;
using RestSharp;
using System.Linq;
using System.Net;


namespace RobotApocalypse
{
    public class SurvivorService : ISurvivorService
    {
        private readonly ISurvivorRepository _survivorRepository;
        private readonly ISurvivorInventoryRepository _inventoryRepository;
        public  SurvivorService(ISurvivorRepository survivorRepository,ISurvivorInventoryRepository inventoryRepository)
        {
            _survivorRepository = survivorRepository;
            _inventoryRepository = inventoryRepository; 
        }
        public async Task<int> CreateSurvivor(Survivor model)
        {   

            Survivor survivor = new Survivor();

            if (model.Id==0)//create
            {
                survivor.Id = model.Id;
                survivor.Name = model.Name;
                survivor.Age = model.Age;
                survivor.Gender = model.Gender;
                survivor.Location = model.Location;
                survivor.NoOfWitness = model.NoOfWitness;
                Survivor survivors = await _survivorRepository.AddAsync(survivor);
                return survivor.Id;
            }
            else//update
            {
               var obj =await  _survivorRepository.GetByIdAsync(model.Id); 
                obj.Location = model.Location;
                obj.NoOfWitness = model.NoOfWitness;
                await _survivorRepository.UpdateAsync(obj);
                     return survivor.Id;

            }
        }

        public async Task<int> CreateSurvivorInventory(SurvivorInventory model)
        {
           
            SurvivorInventory survivorInventory = new SurvivorInventory();
            survivorInventory.Id=model.Id;
            survivorInventory.SurvivorId = model.SurvivorId;
            survivorInventory.ResourcesName = model.ResourcesName;  
            survivorInventory.QuantityinGram = model.QuantityinGram;
            SurvivorInventory inventory = await _inventoryRepository.AddAsync(survivorInventory);
            return survivorInventory.Id;    

        }

        

        public async Task<IEnumerable<Survivor>> Infected()
        {
            var survivors = await _survivorRepository.GetAllAsync();
            var toBeZombies = (from a in survivors
                               where a.NoOfWitness>=3
                               select new Survivor
                               {    
                                    Id = a.Id,
                                    Name = a.Name,  
                                    Age = a.Age,
                                    Gender= a.Gender,
                                    Location = a.Location,
                                    NoOfWitness= a.NoOfWitness,
                               }).ToList();

            return toBeZombies;  
        }

        public async Task<double> InfectedInPercentage()
        {
            var survivorsCount = (await _survivorRepository.GetAllAsync()).Count();
            var survivors = await _survivorRepository.GetAllAsync();
            var toBeZombiesCount = (from a in survivors
                               where a.NoOfWitness >= 3
                               select a.Id).ToList().Count();
            double Percentage = (toBeZombiesCount * 100) / survivorsCount;


            return Percentage;
        }

        public async Task<IEnumerable<Survivor>> UnInfected()
        {
            var survivors = await _survivorRepository.GetAllAsync();
            var notToBeZombies = (from a in survivors
                               where a.NoOfWitness < 3
                               select new Survivor
                               {
                                   Id = a.Id,
                                   Name = a.Name,
                                   Age = a.Age,
                                   Gender = a.Gender,
                                   Location = a.Location,
                                   NoOfWitness = a.NoOfWitness,
                               }).ToList();

            return notToBeZombies;
        }

        public async Task<double> UnInfectedInPercentage()
        {

            var survivorsCount = (await _survivorRepository.GetAllAsync()).Count();
            var survivors = await _survivorRepository.GetAllAsync();
            var toBeZombiesCount = (from a in survivors
                                    where a.NoOfWitness <3
                                    select a.Id).ToList().Count();
            double Percentage = (toBeZombiesCount * 100) / survivorsCount;


            return Percentage;
        }




        public async Task<ResponseDto<RobotDto>> GetAllRobots()
        {
            ResponseDto<RobotDto> response;

            try
            {

                String url = "https://robotstakeover20210903110417.azurewebsites.net/robotcpu";

                HttpResponseDto httpResponse = await HttpHelper.GetRequestAsync(url);

                if (httpResponse.StatusCode != HttpStatusCode.Created)
                {
                    response = new ResponseDto<RobotDto>
                    {
                        StatusCode = httpResponse.StatusCode,
                        Data = httpResponse.Content,
                        Error = null
                    };
                }
                else
                {
                    response = new ResponseDto<RobotDto>
                    {
                        StatusCode = httpResponse.StatusCode,
                        Data = httpResponse.Content,
                        Error = null
                    };
                }
            }
            catch (Exception ex)
            {
                response = new ResponseDto<RobotDto>
                {
                    StatusCode = HttpStatusCode.InternalServerError,
                    Error = ex.Message,
                    Data = null
                };
            }

            return response;
           //throw new NotImplementedException();
        }

        public async Task<IEnumerable<RobotDto>> GetRobots()
        {

            IEnumerable<RobotDto> response=null;    
            try
            {
                string url = "https://robotstakeover20210903110417.azurewebsites.net/robotcpu";
                HttpResponseDto httpResponse = await HttpHelper.GetRequestAsync(url);

                if (httpResponse.StatusCode != HttpStatusCode.Created)
                {
                    response = JsonConvert.DeserializeObject<IEnumerable<RobotDto>>(httpResponse.Content);
                }
            }
            catch(Exception ex)
            {
                throw new Exception();
            }
            return response;
        }



    }
}
