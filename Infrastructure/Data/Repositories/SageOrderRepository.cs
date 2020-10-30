using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Interfaces.Repositories;
using Core.Entities;

namespace Infrastructure.Data.Repositories
{
    public class SageOrderRepository : ISageOrderRepository
    {
        public int AddAsync(Order entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<Order>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Order> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(Order entity)
        {
            throw new NotImplementedException();
        }
    }
}
