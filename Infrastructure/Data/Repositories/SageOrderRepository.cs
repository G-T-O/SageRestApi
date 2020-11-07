using System;
using System.Threading.Tasks;
using Application.Interfaces.Sage.Repositories;
using Core.Dto;

namespace Infrastructure.Data.Repositories
{
    public class SageOrderRepository : ISageOrderRepository
    {
        public Task<int> AddAsync(Order entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Order> GetByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(Order entity)
        {
            throw new NotImplementedException();
        }
    }
}