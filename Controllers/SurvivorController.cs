using Microsoft.AspNetCore.Mvc;

namespace RobotApocalypse.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SurvivorController: ControllerBase
    {

        public readonly ISurvivorService _survivorService;
        public SurvivorController(ISurvivorService survivorService)
        {
            _survivorService = survivorService;
        }
        
        [HttpPost("CreateSurvivor")]
        public async Task<IActionResult> CreateSurvivor(Survivor model)
        {
            
            return Ok(await _survivorService.CreateSurvivor(model));
        }


        [HttpPost("CreateSurvivorInventory")]
        public async Task<IActionResult> CreateSurvivorInventory(SurvivorInventory model)
        {

            return Ok(await _survivorService.CreateSurvivorInventory(model));
        }




        [HttpGet("Infected")]
        public async Task<IActionResult> Infected()
        {

            var response = await _survivorService.Infected();
            return Ok(response);

          
        }
        [HttpGet("UnInfected")]
        public async Task<IActionResult> UnInfected()
        {

            var response = await _survivorService.UnInfected();
            return Ok(response);


        }

        [HttpGet("InfectedInPercentage")]
        public async Task<IActionResult> InfectedInPercentage()
        {

            var response = await _survivorService.InfectedInPercentage();
            return Ok(response);


        }

        [HttpGet("UnInfectedInPercentage")]
        public async Task<IActionResult> UnInfectedInPercentage()
        {

            var response = await _survivorService.UnInfectedInPercentage();
            return Ok(response);


        }

        [HttpGet("GetAllRobots")]
        public async Task<IActionResult> GetRobots()
        {

            var response = await _survivorService.GetRobots();
            return Ok(response);


        }


       
    }
}
