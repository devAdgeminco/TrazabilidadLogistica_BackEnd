using Core.Interfaces;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class CodigoBarrasRepository: ICodigoBarrasRepository
    {
        private readonly string ConnectionString;
        public CodigoBarrasRepository(IConfiguration configuration)
        {
            ConnectionString = ConfigurationExtensions.GetConnectionString(configuration, "BDADGintegra");
        }

        public async Task<IEnumerable<dynamic>> GetBarraCodigoOC(string codigo, int empresa)
        {
            using var connection = new SqlConnection(ConnectionString);
            return await connection.QueryAsync("usp_GetCodigoBarraOC", param: new { codigo = codigo, empresa = empresa }, commandType: CommandType.StoredProcedure);
        }
        public async Task<IEnumerable<dynamic>> GetBarraCodigoOCD(string codigo, int empresa)
        {
            using var connection = new SqlConnection(ConnectionString);
            return await connection.QueryAsync("usp_GetCodigoBarraOCD", param: new { codigo = codigo, empresa = empresa }, commandType: CommandType.StoredProcedure);
        }
    }
}
