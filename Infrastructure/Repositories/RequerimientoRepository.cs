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
    public class RequerimientoRepository:IRequerimientoRepository
    {
        private readonly string ConnectionString;
        public RequerimientoRepository(IConfiguration configuration)
        {
            ConnectionString = ConfigurationExtensions.GetConnectionString(configuration, "BDRsFaccar");
        }

        public async Task<IEnumerable<dynamic>> GetRequerimientos(DateTime fecIni, DateTime fecFin)
        {
            using var connection = new SqlConnection(ConnectionString);
            return await connection.QueryAsync("usp_GetRequerimientos", param: new { fecIni = fecIni, fecFin = fecFin }, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<dynamic>> GetRequerimientoDetalle(string idReq)
        {
            using var connection = new SqlConnection(ConnectionString);
            return await connection.QueryAsync("usp_GetRequerimientoDetalle", param: new { idReq = idReq }, commandType: CommandType.StoredProcedure);
        }

    }
}
