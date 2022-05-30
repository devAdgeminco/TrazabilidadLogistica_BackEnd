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
    public class CompanyRepository: ICompanyRepository
    {
        private readonly string ConnectionString;
        public CompanyRepository(IConfiguration configuration)
        {
            ConnectionString = ConfigurationExtensions.GetConnectionString(configuration, "BDADGintegra");
        }

        public async Task<IEnumerable<dynamic>> GetCompanies()
        {
            using var connection = new SqlConnection(ConnectionString);
            return await connection.QueryAsync("sp_GetCompanies", commandType: CommandType.StoredProcedure);
        }
        public async Task<IEnumerable<dynamic>> ValidarEmpresaOC(string ruc)
        {
            using var connection = new SqlConnection(ConnectionString);
            return await connection.QueryAsync("usp_ValidarEmpresaOC", param: new { ruc = ruc }, commandType: CommandType.StoredProcedure);
        }
    }
}
