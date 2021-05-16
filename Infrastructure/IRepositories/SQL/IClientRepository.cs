using Core.Dto;
using System.Threading.Tasks;

namespace Infrastructure.IRepositories.SQL
{
    public interface IClientRepository
    {
        Task<Client> GetByIdAsync(string sageCode);
        Task<bool> ClientExistByIdAsync(string sageCode);
    }
}