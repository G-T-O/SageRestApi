using Application.IServices;
using Core.Dto;
using Infrastructure.IRepositories.Sage;
using System.Threading.Tasks;

namespace Application.Services
{
    public class SageClientService : ISageClientService
    {
        private readonly ISageClientRepository _sageClientRepository;

        public SageClientService(ISageClientRepository sageClientRepository)
        {
            _sageClientRepository = sageClientRepository;
        }

        public async Task<int> AddAsync(Client client)
        {
            return await _sageClientRepository.AddAsync(client);
        }

        public async Task<int> DeleteAsync(string id)
        {
            return await _sageClientRepository.DeleteAsync(id);
        }

        public async Task<Client> GetByIdAsync(string id)
        {
           return await _sageClientRepository.GetByIdAsync(id);
        }

        public async Task<int> UpdateAsync(Client client)
        {
            return await _sageClientRepository.UpdateAsync(client);
        }
    }
}
