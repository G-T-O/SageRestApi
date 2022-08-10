using Infrastructure.Data.IDBAccess;
using Microsoft.Extensions.Configuration;
using Objets100cLib;

namespace Infrastructure.Data.DbAccess
{
   public class SageAccess : ISageAccess
    {
        private readonly IConfiguration _configuration;
        private readonly string _sageUsername;
        private readonly string _sageUserPwd;
        private readonly string _sageDatabaseName;
        private readonly string _sageDetabaseInstance;
        private static readonly BSCIALApplication100c _sageDatabase = new BSCIALApplication100c();
        private static readonly object _databaseLock = new object(); 

        public BSCIALApplication100c GetSageDatabase { get => _sageDatabase; }
        public string GetUsername { get => _sageUsername; }
        public string GetUserPwd { get => _sageUserPwd; }
        public string GetDatabaseName { get => _sageDatabaseName; }
        public string GetDatabaseInstance { get => _sageDetabaseInstance; }
        public object DatabaseLock { get => _databaseLock; }

        public SageAccess(IConfiguration configuration)
        {
            _configuration = configuration;
            _sageUsername = _configuration.GetSection("SageConnection").GetSection("User").Value;
            _sageUserPwd = _configuration.GetSection("SageConnection").GetSection("Password").Value;
            _sageDatabaseName = _configuration.GetSection("SageConnection").GetSection("DatabaseName").Value;
            _sageDetabaseInstance = _configuration.GetSection("SageConnection").GetSection("DatabaseServerName").Value;
        }
    }
}