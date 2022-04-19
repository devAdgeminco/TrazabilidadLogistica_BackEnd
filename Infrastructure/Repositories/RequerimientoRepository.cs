﻿using Core.Interfaces;
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

        public async Task<IEnumerable<dynamic>> getOrdenCompra(DateTime fecIni, DateTime fecFin)
        {
            using var connection = new SqlConnection(ConnectionString);
            return await connection.QueryAsync("usp_GetOrdenCompra", param: new { fecIni = fecIni, fecFin = fecFin }, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<dynamic>> getOrdenCompraDetalle(string id)
        {
            using var connection = new SqlConnection(ConnectionString);
            return await connection.QueryAsync("usp_GetOrdenCompraDetalle", param: new { id = id }, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<dynamic>> getPartesEntrada(DateTime fecIni, DateTime fecFin)
        {
            using var connection = new SqlConnection(ConnectionString);
            return await connection.QueryAsync("usp_GetPartesEntrada", param: new { fecIni = fecIni, fecFin = fecFin }, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<dynamic>> getPartesEntradaDetalle(string id)
        {
            using var connection = new SqlConnection(ConnectionString);
            return await connection.QueryAsync("usp_GetPartesEntradaDetalle", param: new { id = id }, commandType: CommandType.StoredProcedure);
        }
    }
}