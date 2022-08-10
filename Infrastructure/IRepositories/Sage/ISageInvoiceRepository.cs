using Core.Dto;
using System.Threading.Tasks;

namespace Infrastructure.IRepositories.Sage
{
    public interface ISageInvoiceRepository
    {
        Task<string> Create(Invoice invoice);
    }
}