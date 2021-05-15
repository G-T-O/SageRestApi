using Infrastructure.Data.IDBAccess;
using Application.Interfaces.Repositories;
using Core.Dto;
using Dapper;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly ISQLDataAccess _dapperAccess;
        public ClientRepository(ISQLDataAccess dapperAccess)
        {
            _dapperAccess = dapperAccess;
        }
        public async Task<int> AddAsync(Client client)
        {
            using (var connection = new SqlConnection(_dapperAccess.GetConnectionString))
            {
                return await connection.ExecuteAsync("INSERT INTO F_COMPTET (CT_Num) VALUES (@CT_Num)", client);
            }
        }

        public async Task<int> DeleteAsync(string CT_Num)
        {
            using (var connection = new SqlConnection(_dapperAccess.GetConnectionString))
            {
                return await connection.ExecuteAsync("DELETE F_COMPTET WHERE CT_Num = @CT_Num", new { CT_Num });
            }
        }

        public async Task<Client> GetByIdAsync(string CT_Num)
        {
            using (var connection = new SqlConnection(_dapperAccess.GetConnectionString))
            {
                return await connection.QueryFirstOrDefaultAsync<Client>("SELECT CT_Num FROM F_COMPTET WHERE CT_Num = @CT_Num", new { CT_Num });
            }
        }

        public async Task<int> UpdateAsync(Client client)
        {
            using (var connection = new SqlConnection(_dapperAccess.GetConnectionString))
            {
                return await connection.ExecuteAsync("UPDATE F_COMPTET SET CT_Siret = @CT_Siret WHERE CT_Num=@CT_Num", client);
            }
        }
    }
}