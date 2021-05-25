using Application.IServices;
using Core.Dto;
using Infrastructure.Data.Mapper;
using Infrastructure.IRepositories.Sage;
using Infrastructure.IRepositories.SQL;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;
        private readonly ISageClientRepository _sageClientRepository;

        public ClientService(IClientRepository clientRepository, ISageClientRepository sageClientRepository)
        {
            _clientRepository = clientRepository;
            _sageClientRepository = sageClientRepository;
        }
        public Task<string> Create(Client client)
        {
            return  _sageClientRepository.Create(client);
        } 

        public async Task<int> Delete(string id)
        {
            return await _sageClientRepository.Delete(id);
        }

        public async Task<Client> GetByIdAsync(string id)
        {
           return await ObjectMapper.ClientEntityToDtoClient(await _clientRepository.GetByIdAsync(id));
        }

        public async Task<int> Update(Client client)
        {
            return await _sageClientRepository.Update(client);
        }
    }
}