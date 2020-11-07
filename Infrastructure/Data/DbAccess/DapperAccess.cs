using Application.Interfaces.Access;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Data.DbAccess
{
    public class DapperAccess : IDapperAccess
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        public string GetConnectionString { get => _connectionString; }
    public DapperAccess(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetSection("ConnectionString").GetSection("DefaultConnection").Value;
        }
    }
}