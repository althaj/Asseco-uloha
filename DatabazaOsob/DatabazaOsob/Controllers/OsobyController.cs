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

        public OsobyController(IServiceManager serviceManager)
        {
            this.serviceManager = serviceManager;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(serviceManager.GetOsoba(id));
            }
            catch (EntityNotFoundException)
            {
                return NotFound();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] OsobaDTO value)
        {
            try
            {
                return Ok(serviceManager.CreateOsoba(value));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
