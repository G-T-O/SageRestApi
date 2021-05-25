using Infrastructure.Data.IDBAccess;
using Dapper;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Infrastructure.IRepositories.SQL;
using System;
using Core.Entities;

namespace Infrastructure.Data.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly ISQLDataAccess _dapperAccess;
        public ClientRepository(ISQLDataAccess dapperAccess)
        {
            _dapperAccess = dapperAccess;
        }

        public Task<bool> ClientExistByIdAsync(string sageCode)
        {
            throw new System.NotImplementedException();
        }

        public async Task<ClientEntity> GetByIdAsync(string CT_Num)
        {
            if (string.IsNullOrEmpty(CT_Num))
                throw new Exception("Client not found");
            using (var connection = new SqlConnection(_dapperAccess.GetConnectionString))
            {
                var result = await connection.QueryFirstOrDefaultAsync<Core.Entities.ClientEntity>("SELECT * FROM F_COMPTET WHERE CT_Num = @CT_Num", new { CT_Num });
                if (result == null)
                    throw new Exception("Client not found");
                return result;
            }
        }
    }
}