using Core.Dto;
using System.Threading.Tasks;

namespace Application.IServices
{
    public interface IClientService
    {
        Task<Client> GetByIdAsync(string id);
        Task<string> Create(Client entity);
        Task<int> Update(Client entity);
        Task<int> Delete(string id);
    }
}