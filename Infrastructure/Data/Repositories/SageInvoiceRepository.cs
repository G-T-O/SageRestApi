using Application.Interfaces.Repositories;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repositories
{
    public class SageInvoiceRepository : ISageInvoiceRepository
    {
        public int AddAsync(Invoice entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<Invoice>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Invoice> GetByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(Invoice entity)
        {
            throw new NotImplementedException();
        }
    }
}
