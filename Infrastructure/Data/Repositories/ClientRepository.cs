using Application.Interfaces.Repositories;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repositories
{
    public class ClientRepository : IClientRepository
    {
        public int AddAsync(Client entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<Client>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Client> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(Client entity)
        {
            throw new NotImplementedException();
        }
    }
}
