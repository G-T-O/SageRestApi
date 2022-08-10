using Infrastructure.Data.IDBAccess;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Data.DbAccess
{
    public class SQLDataAccess : ISQLDataAccess
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        public string GetConnectionString { get => _connectionString; }
    public SQLDataAccess(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetSection("ConnectionString").GetSection("DefaultConnection").Value;
        }
    }
}