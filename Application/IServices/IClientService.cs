using Core.Dto;
using System.Threading.Tasks;

namespace Application.IServices
{
    public interface IClientService
    {
        Task<Client> GetByIdAsync(string id);
        Task<string> Create(Client client);
        Task<int> Update(Client client);
        Task<int> Delete(string id);
    }
}