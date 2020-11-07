using Core.Dto;
using System.Threading.Tasks;

namespace Application.Interfaces.Services
{
    public interface IClientService
    {
        Task<Client> GetByIdAsync(string id);
        Task<int> AddAsync(Client entity);
        Task<int> UpdateAsync(Client entity);
        Task<int> DeleteAsync(string id);
    }
}