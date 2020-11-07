using Application.Interfaces.Sage.Repositories;
using Application.Interfaces.Services;
using Core.Dto;
using System.Threading.Tasks;

namespace Application.Services
{
    public class SageOrderService : ISageOrderService
    {
        private ISageOrderRepository _sageOrderRepository;
        public SageOrderService(ISageOrderRepository sageOrderRepository)
        {
            _sageOrderRepository = sageOrderRepository;
        }
        public async Task<int> AddAsync(Order order)
        {
         return await _sageOrderRepository.AddAsync(order);
        }

        public async Task<int> DeleteAsync(string id)
        {
          return await _sageOrderRepository.DeleteAsync(id);
        }

        public async Task<Order> GetByIdAsync(string id)
        {
            return await _sageOrderRepository.GetByIdAsync(id);
        }

        public async Task<int> UpdateAsync(Order order)
        {
            return await _sageOrderRepository.UpdateAsync(order);
        }
    }
}
