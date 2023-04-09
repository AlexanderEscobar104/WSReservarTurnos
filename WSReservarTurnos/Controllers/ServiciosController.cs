using Microsoft.AspNetCore.Mvc;
using WSReservarTurnos.Models;
using WSReservarTurnos.Services;

namespace WSReservarTurnos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiciosController : Controller
    {

        private readonly ServiciosService _serviciosService;
        public ServiciosController(ServiciosService serviciosService)
        {
            _serviciosService = serviciosService;
        }

        /// <summary>
        /// metodo para retornar los servicios
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("listServicios")]
        public IActionResult listServicios()
        {
            List<Servicios> serviciosList = new List<Servicios>();
            serviciosList = _serviciosService.GetAll();
            return Ok(serviciosList);
        }
    }
}
