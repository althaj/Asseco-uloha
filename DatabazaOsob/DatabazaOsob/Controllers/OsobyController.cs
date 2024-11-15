using DatabazaOsob.CRUDService.DTO;
using DatabazaOsob.CRUDService.Exceptions;
using DatabazaOsob.CRUDService.Service;
using Microsoft.AspNetCore.Mvc;


namespace DatabazaOsob.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OsobyController : ControllerBase
    {
        private readonly IServiceManager serviceManager;
        private readonly ILogger<OsobyController> logger;

        public OsobyController(IServiceManager serviceManager, ILogger<OsobyController> logger)
        {
            this.serviceManager = serviceManager;
            this.logger = logger;
            logger.LogDebug($"NLog injected into {typeof(OsobyController).Name}.");
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                logger.LogInformation("Getting Osoba with Id {0}.", id);
                return Ok(serviceManager.GetOsoba(id));
            }
            catch (EntityNotFoundException ex)
            {
                logger.LogError(ex.Message);
                return NotFound();
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] OsobaDTO osoba)
        {
            try
            {
                logger.LogInformation("Inserting Osoba with entity {0}.", osoba);
                return Ok(serviceManager.CreateOsoba(osoba));
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return BadRequest();
            }
        }
    }
}
