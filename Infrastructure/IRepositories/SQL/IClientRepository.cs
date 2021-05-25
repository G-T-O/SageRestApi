using Core.Entities;
using System.Threading.Tasks;

namespace Infrastructure.IRepositories.SQL
{
    public interface IClientRepository
    {
        Task<ClientEntity> GetByIdAsync(string sageCode);
        Task<bool> ClientExistByIdAsync(string sageCode);
    }
}