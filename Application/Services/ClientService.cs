using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Core.Dto;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;

        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<int> AddAsync(Client client)
        {
            return await _clientRepository.AddAsync(client);
        } 

        public async Task<int> DeleteAsync(string id)
        {
            return await _clientRepository.DeleteAsync(id);
        }

        public async Task<Client> GetByIdAsync(string id)
        {
           return await _clientRepository.GetByIdAsync(id);
        }

        public async Task<int> UpdateAsync(Client client)
        {
            return await _clientRepository.UpdateAsync(client);
        }
    }
}