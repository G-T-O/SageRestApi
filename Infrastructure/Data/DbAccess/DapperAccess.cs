using Application.Interfaces.Access;
using System;

namespace Infrastructure.Data.DbAccess
{
    public class DapperAccess : IDapperAccess
    {
        private readonly string _connectionString;
        public string GetConnectionString { get => _connectionString; }
    public DapperAccess()
        {
            _connectionString = "Data Source=DESKTOP-OO9BUGL;Initial Catalog=S_QUALIFELEC;Integrated Security=True;MultipleActiveResultSets=True";
            //TO DO Call the string from AppSettings
        }
    }
}