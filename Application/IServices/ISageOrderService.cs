using Core.Dto.Requests;
using System.Threading.Tasks;

namespace Application.IServices
{
    public interface ISageOrderService
    {
        Task<string> Create(OrderRequest order);
        Task<int> Delete(string id);
    }
}