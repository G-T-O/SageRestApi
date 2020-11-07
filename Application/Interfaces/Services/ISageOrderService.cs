using Core.Dto;
using System.Threading.Tasks;

namespace Application.Interfaces.Services
{
    public interface ISageOrderService
    {
        Task<Order> GetByIdAsync(string id);
        Task<int> AddAsync(Order order);
        Task<int> UpdateAsync(Order order);
        Task<int> DeleteAsync(string id);
    }
}
