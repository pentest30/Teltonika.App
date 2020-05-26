using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Teeltonika.Application.Dtos;
using Teeltonika.Application.Service;

namespace Teltonika.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {

        private readonly ILogger<VehicleController> _logger;
        private readonly IVehicleService _service;

        public VehicleController(ILogger<VehicleController> logger, IVehicleService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        public Task<VehicleDto []> Get()
        {
            return _service.GetAllAsync();
        }
    }
}
