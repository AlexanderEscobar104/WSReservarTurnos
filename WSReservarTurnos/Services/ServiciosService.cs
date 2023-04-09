using Microsoft.Data.SqlClient;
using System.Data;
using WSReservarTurnos.Connection;
using WSReservarTurnos.Models;

namespace WSReservarTurnos.Services
{
    public class ServiciosService
    {

        SqlConnection _connection = null;
        SqlCommand _command = null;
        ConnectionBd _connectionBd = null;
       
        /// <summary>
        /// metodo para listar los servicios
        /// </summary>
        /// <returns></returns>
        public List<Servicios> GetAll()
        {
            _connectionBd = new ConnectionBd();
            List<Servicios> serviciosList = new List<Servicios>();
            SqlDataReader dr = null;
            try
            {
               //abre la nueva conexion a la bd
                using (_connection = new SqlConnection(_connectionBd.GetConnectionString()))
                {
                    _command = _connection.CreateCommand();
                    _command.CommandType = System.Data.CommandType.StoredProcedure;
                    _command.CommandText = "[dbo].[Select_Servicios]";
                    _connection.Open();
                    dr = _command.ExecuteReader();
                    while (dr.Read())
                    {
                        Servicios servicios  = new Servicios();
                        servicios.id_servicio = Convert.ToInt32(dr["id_servicio"]);
                        servicios.nom_servicio = dr["nom_servicio"].ToString()!;
                        serviciosList.Add(servicios);
                    }
                    //se cierra conexión
                    _connection.Close();
                }
                return serviciosList;
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
