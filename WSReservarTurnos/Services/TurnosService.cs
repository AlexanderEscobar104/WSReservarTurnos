using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using System.Data;
using WSReservarTurnos.Connection;
using WSReservarTurnos.Models;

namespace WSReservarTurnos.Services
{
    public class TurnosService
    {
        SqlConnection _connection = null;
        SqlCommand _command = null;
        ConnectionBd _connectionBd = null;
        /// <summary>
        /// metodo para generar y retornar turnos de acuerdo a los parametros ingresados
        /// </summary>
        /// <param name="Fecha_inicio"></param>
        /// <param name="Fecha_fin"></param>
        /// <param name="Id_Servicio"></param>
        /// <returns></returns>
        public List<Turnos> InsertGetAll(DateTime Fecha_inicio , DateTime Fecha_fin, int Id_Servicio)
        {
            _connectionBd = new ConnectionBd();
            List<Turnos> turnosList = new List<Turnos>();
            SqlDataReader dr = null;
            try
            {
                //abre la nueva conexion a la bd
                using (_connection = new SqlConnection(_connectionBd.GetConnectionString()))
                {
                    _command = _connection.CreateCommand();
                    _command.CommandType = System.Data.CommandType.StoredProcedure;
                    _command.CommandText = "[dbo].[Insert_Turnos]";
                    _command.Parameters.AddWithValue("@Fecha_inicio", SqlDbType.Date).Value = Fecha_inicio;
                    _command.Parameters.AddWithValue("@Fecha_fin", SqlDbType.Date).Value = Fecha_fin;
                    _command.Parameters.AddWithValue("@Id_Servicio", SqlDbType.Int).Value = Id_Servicio;
                    _connection.Open();
                    dr = _command.ExecuteReader();
                    while (dr.Read())
                    {

                        Turnos turnos = new Turnos();
                        turnos.id_servicio = Convert.ToInt32(dr["id_servicio"]);
                        turnos.fecha_turno = Convert.ToDateTime( dr["FECHA_TURNO"].ToString());
                        turnos.hora_inicio = Convert.ToDateTime(dr["HORA_INICIO"].ToString());
                        turnos.hora_fin = Convert.ToDateTime(dr["HORA_FIN"].ToString());
                        turnos.estado = dr["ESTADO"].ToString()!;
                        turnosList.Add(turnos);
                    }
                    //se cierra conexión
                    _connection.Close();
                }
                return turnosList;
            }
            catch (Exception ex)
            {
                return null;

            }
            finally
            {
                if (dr != null)
                {
                    dr.Close();
                }
                if (_connection != null && _connection.State == System.Data.ConnectionState.Open)
                {
                    _connection.Close();
                }
            }
        }

        /// <summary>
        /// metodo para traer todos los turnos
        /// </summary>
        /// <returns></returns>
        public List<Turnos> GetAll()
        {
            _connectionBd = new ConnectionBd();
            List<Turnos> turnosList = new List<Turnos>();
            SqlDataReader dr = null;
            try
            {
                //abre la nueva conexion a la bd
                using (_connection = new SqlConnection(_connectionBd.GetConnectionString()))
                {
                    _command = _connection.CreateCommand();
                    _command.CommandType = System.Data.CommandType.StoredProcedure;
                    _command.CommandText = "[dbo].[Select_Turnos]";
                    _connection.Open();
                    dr = _command.ExecuteReader();
                    while (dr.Read())
                    {

                        Turnos turnos = new Turnos();
                        turnos.id_servicio = Convert.ToInt32(dr["id_servicio"]);
                        turnos.fecha_turno = Convert.ToDateTime(dr["FECHA_TURNO"].ToString());
                        turnos.hora_inicio = Convert.ToDateTime(dr["HORA_INICIO"].ToString());
                        turnos.hora_fin = Convert.ToDateTime(dr["HORA_FIN"].ToString());
                        turnos.estado = dr["ESTADO"].ToString()!;
                        turnosList.Add(turnos);
                    }
                    //se cierra conexión
                    _connection.Close();
                }
                return turnosList;
            }
            catch (Exception ex)
            {
                return null;

            }
            finally
            {
                if (dr != null)
                {
                    dr.Close();
                }
                if (_connection != null && _connection.State == System.Data.ConnectionState.Open)
                {
                    _connection.Close();
                }
            }
        }
    }
}
