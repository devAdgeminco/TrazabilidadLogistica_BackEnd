using Core.Entities;
using Dapper;
using Core.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data;

namespace Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly string ConnectionString;
        public UserRepository(IConfiguration configuration)
        {
            ConnectionString = ConfigurationExtensions.GetConnectionString(configuration, "BDMovilidad");
        }
        public async Task<IEnumerable<dynamic>> GetUsers()
        {
            using var connection = new SqlConnection(ConnectionString);
            return await connection.QueryAsync("sp_GetUsuarios", commandType: CommandType.StoredProcedure);
        }
        public async Task<IEnumerable<dynamic>> GetUser(string login, string CodEmpresa)
        {
            using var connection = new SqlConnection(ConnectionString);
            return await connection.QueryAsync("usp_Usuario_ObtenerxLogin", param : new { Login = login, CodEmpresa = CodEmpresa },commandType: CommandType.StoredProcedure);
        }
    }
}
