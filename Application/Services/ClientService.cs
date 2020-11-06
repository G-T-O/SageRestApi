using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Core.Dto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ClientService : IClientService<Client>
    {
        private readonly IClientRepository _clientRepository;

        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public Task<int> AddAsync(Client entity)
        {
            throw new NotImplementedException();
        } 

        public Task<int> DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Client> GetByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(Client entity)
        {
            throw new NotImplementedException();
        }
    }
}