using Application.Interfaces.Access;
using Application.Interfaces.Repositories;
using Core.Entities;
using Objets100cLib;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repositories
{
    public class SageClientRepository : ISageClientRepository
    {
        private readonly ISageAccess _sageAccess;
        public SageClientRepository (ISageAccess sageAccess)
        {
            _sageAccess = sageAccess;
        }

        private bool OpenDatabase()
        {
            try
            {
                _sageAccess.GetSageDatabase.CompanyServer = _sageAccess.GetDatabaseInstance;
                _sageAccess.GetSageDatabase.CompanyDatabaseName = _sageAccess.GetDatabaseName;
                _sageAccess.GetSageDatabase.Loggable.UserName = _sageAccess.GetUsername;
                _sageAccess.GetSageDatabase.Loggable.UserPwd = _sageAccess.GetUserPwd;
                _sageAccess.GetSageDatabase.Open();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public async Task<int> AddAsync(Client client)
        {
            lock (_sageAccess.DatabaseLock)
            {
                if (!OpenDatabase())
                {
                    return 1;
                }
                IBOClient3 sageClient = null;
                return 0;
            }
        }

        public Task<int> DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<Client>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Client> GetByIdAsync(string CT_Num)
        {
            throw new NotImplementedException();
        }
        public Task<int> UpdateAsync(Client entity)
        {
            throw new NotImplementedException();
        }
    }
}
