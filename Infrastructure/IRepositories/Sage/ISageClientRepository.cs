using Core.Dto;
using System.Threading.Tasks;

namespace Infrastructure.IRepositories.Sage
{
    public interface ISageClientRepository
    {
        Task<string> Create(Client client);
        Task<int> Update(Client client);
        Task<int> Delete(string sageCode);
    }
}