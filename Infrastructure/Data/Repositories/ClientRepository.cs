using Application.Interfaces.Access;
using Application.Interfaces.Repositories;
using Core.Entities;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly IDapperAccess _dapperAccess;
        public ClientRepository(IDapperAccess dapperAccess)
        {
            _dapperAccess = dapperAccess;
        }
        public int AddAsync(Client entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<Client>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Client> GetByIdAsync(string CT_Num)
        {
            using (var connection = new SqlConnection(_dapperAccess.GetConnectionString))
            {
                return await connection.QueryFirstOrDefaultAsync<Client>("SELECT * FROM F_COMPTET WHERE CT_Num =@CT_Num",new { CT_Num});
            }
        }

        public Task<int> UpdateAsync(Client entity)
        {
            throw new NotImplementedException();
        }
    }
}
