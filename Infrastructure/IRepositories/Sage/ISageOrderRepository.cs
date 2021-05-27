using Core.Dto.Requests;
using System.Threading.Tasks;

namespace Infrastructure.IRepositories.Sage
{
   public interface ISageOrderRepository
    {
        Task<string> Create(OrderRequest order);
        Task<int> Delete(string orderNum);
    }
}