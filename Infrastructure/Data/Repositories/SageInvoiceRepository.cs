using Core.Dto;
using Infrastructure.IRepositories.Sage;
using System;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repositories
{
    public class SageInvoiceRepository : ISageInvoiceRepository
    {
        public Task<string> Create(Invoice invoice)
        {
            throw new NotImplementedException();
        }
    }
}