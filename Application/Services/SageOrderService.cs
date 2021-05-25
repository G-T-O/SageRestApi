using Application.IServices;
using Core.Dto;
using Infrastructure.IRepositories.Sage;
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
        public async Task<string> Create(Order order)
        {
         return await _sageOrderRepository.Create(order);
        }

        public async Task<int> Delete(string id)
        {
          return await _sageOrderRepository.Delete(id);
        }
    }
}