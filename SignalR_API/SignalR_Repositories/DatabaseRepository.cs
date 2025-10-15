using Microsoft.Extensions.Options;
using SignalR_Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR_Repositories
{
    public class DatabaseRepository
    {
        private readonly string _connectionString;

        public DatabaseRepository(IOptions<DatabaseSettings> options)
        {
            _connectionString = options.Value.ConnectionString;
        }
    }
}
