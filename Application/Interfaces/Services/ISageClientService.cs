using Core.Dto;
using System.Threading.Tasks;

namespace Application.Interfaces.Services
{
   public interface ISageClientService
    {
        Task<Client> GetByIdAsync(string id);
        Task<int> AddAsync(Client client);
        Task<int> UpdateAsync(Client client);
        Task<int> DeleteAsync(string id);
    }
}