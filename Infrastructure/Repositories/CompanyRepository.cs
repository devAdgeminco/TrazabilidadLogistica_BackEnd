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
            ConnectionString = ConfigurationExtensions.GetConnectionString(configuration, "BDMovilidad");
        }

        public async Task<IEnumerable<dynamic>> GetCompanies()
        {
            using var connection = new SqlConnection(ConnectionString);
            return await connection.QueryAsync("sp_GetCompanies", commandType: CommandType.StoredProcedure);
        }
    }
}
