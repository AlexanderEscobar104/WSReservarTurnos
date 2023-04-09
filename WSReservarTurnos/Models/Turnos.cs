namespace WSReservarTurnos.Models
{
    public class Turnos
    {

        public int id_servicio { get; set; }
        public DateTime fecha_turno { get; set; }
        public DateTime hora_inicio { get; set; }
        public DateTime hora_fin { get; set; }
        public string estado { get; set; }

		
    }
}
