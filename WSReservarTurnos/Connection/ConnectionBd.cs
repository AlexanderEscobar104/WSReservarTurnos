using Microsoft.Data.SqlClient;

namespace WSReservarTurnos.Connection
{
    public class ConnectionBd
    {
        SqlConnection _connection = null;
        SqlCommand _command = null;

        public ConnectionBd()
        {
        }

        public static IConfiguration configuration { get; set; }

        public string GetConnectionString()
        {
            var buildes = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");

            configuration = buildes.Build();
            return configuration.GetConnectionString("DefaultConnection");
        }
    }
}
