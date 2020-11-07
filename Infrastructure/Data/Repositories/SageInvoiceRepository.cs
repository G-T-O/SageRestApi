using Application.Interfaces.Sage.Repositories;
using Core.Dto;
using System;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repositories
{
    public class SageInvoiceRepository : ISageInvoiceRepository
    {
        public Task<int> AddAsync(Invoice entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(string id)
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