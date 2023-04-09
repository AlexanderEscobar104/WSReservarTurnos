using Microsoft.AspNetCore.Mvc;
using WSReservarTurnos.Models;
using WSReservarTurnos.Services;

namespace WSReservarTurnos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TurnosController : Controller
    {
        private readonly TurnosService _turnosService;
        public TurnosController(TurnosService turnosService) {
            _turnosService = turnosService; 
        }
        /// <summary>
        /// metodo para traer todos los turnos
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("getTurnos")]
        public IActionResult getTurnos()
        {
            List<Turnos> turnosList = new List<Turnos>();
            turnosList = _turnosService.GetAll();
            return Ok(turnosList);
        }

        /// <summary>
        /// metodo para insertar y retornar los turnos 
        /// </summary>
        /// <param name="Fecha_inicio"></param>
        /// <param name="Fecha_fin"></param>
        /// <param name="Id_Servicio"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("listTurnos")]
        public IActionResult listTurnos([FromQuery] DateTime Fecha_inicio, DateTime Fecha_fin, int Id_Servicio)
        {
            List<Turnos> turnosList = new List<Turnos>();
            turnosList = _turnosService.InsertGetAll(Fecha_inicio, Fecha_fin, Id_Servicio);
            return Ok(turnosList);
        }
    }
}
