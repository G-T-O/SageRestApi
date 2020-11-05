using Application.Interfaces.Services;
using System;
using System.Collections.Generic;
using Core.Dto;
using System.Threading.Tasks;
using Application.Interfaces.Sage.Repositories;

namespace Application.Services
{
    public class SageClientService : ISageClientService<Client>
    {
        private readonly ISageClientRepository _sageClientRepository;

        public SageClientService(ISageClientRepository sageClientRepository)
        {
            _sageClientRepository = sageClientRepository;
        }

        public Task<int> AddAsync(Client entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<Client>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Client> GetByIdAsync(string id)
        {
           return await _sageClientRepository.GetByIdAsync(id);
        }

        public Task<int> UpdateAsync(Client entity)
        {
            throw new NotImplementedException();
        }
    }
}
