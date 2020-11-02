using Objets100cLib;

namespace Application.Interfaces.Access
{
    public interface ISageAccess
    {
        public BSCIALApplication100c GetSageDatabase { get; }
        public object DatabaseLock { get; }
        public string GetUsername { get; }
        public string GetUserPwd { get; }
        public string GetDatabaseName { get; }
        public string GetDatabaseInstance { get; }
    }
}
