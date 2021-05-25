using Core.Dto;
using System.Threading.Tasks;

namespace Application.IServices
{
    public interface ISageOrderService
    {
        Task<string> Create(Order order);
        Task<int> Delete(string id);
    }
}