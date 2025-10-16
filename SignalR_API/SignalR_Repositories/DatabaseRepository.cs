using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;

namespace SignalR_Repositories
{
    public class DatabaseRepository : IDatabaseRepository
    {
        private readonly string _connectionString;

        public DatabaseRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public SqlConnection GetConnetion()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
