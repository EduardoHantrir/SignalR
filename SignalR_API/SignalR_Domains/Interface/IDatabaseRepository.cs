using Microsoft.Data.SqlClient;

namespace SignalR_Repositories
{
    public interface IDatabaseRepository
    {
        SqlConnection GetConnetion();
    }
}