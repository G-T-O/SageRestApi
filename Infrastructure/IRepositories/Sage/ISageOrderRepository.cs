using Core.Dto;
using System.Threading.Tasks;

namespace Infrastructure.IRepositories.Sage
{
   public interface ISageOrderRepository
    {
        Task<string> Create(Order order);
        Task<int> Delete(string orderNum);
    }
}