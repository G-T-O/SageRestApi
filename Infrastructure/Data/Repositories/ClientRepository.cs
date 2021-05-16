using Infrastructure.Data.IDBAccess;
using Core.Dto;
using Dapper;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Infrastructure.IRepositories.SQL;

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

        public async Task<Client> GetByIdAsync(string CT_Num)
        {
            using (var connection = new SqlConnection(_dapperAccess.GetConnectionString))
            {
                return await connection.QueryFirstOrDefaultAsync<Client>("SELECT CT_Num FROM F_COMPTET WHERE CT_Num = @CT_Num", new { CT_Num });
            }
        }
    }
}