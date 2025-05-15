using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoApiCrud.Repositories;

namespace MongoApiCrud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppController : ControllerBase
    {
        private readonly ILogger<AppController> _logger;
        private readonly AppRepository _appRepository;
        public AppController(ILogger<AppController> logger, AppRepository appRepository) 
        {
            _logger = logger;
            _appRepository = appRepository;
        }

        [HttpGet]
        [Route("get")]
        public async Task<IActionResult> Get()
        {
            _logger.LogInformation("Get called");
            var items = await _appRepository.GetPlanet();
            return Ok(items);
        }

        [HttpPost]
        [Route("upsert")]
        public async Task<IActionResult> Upsert([FromBody] Planet planet)
        {
            _logger.LogInformation("Upsert called");
            if (planet == null)
            {
                return BadRequest("Planet is null");
            }
            var item = await _appRepository.UpsertPlanet(planet);
            return Ok(item);
        }
    }
}
