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
        private readonly string ConnectionString2;
        public RequerimientoRepository(IConfiguration configuration)
        {
            ConnectionString = ConfigurationExtensions.GetConnectionString(configuration, "BDADGintegra");
            ConnectionString2 = ConfigurationExtensions.GetConnectionString(configuration, "BDAgenda");
        }

        public async Task<IEnumerable<dynamic>> GetRequerimientos(DateTime fecIni, DateTime fecFin, int empresa)
        {
            using var connection = new SqlConnection(ConnectionString);
            return await connection.QueryAsync("usp_GetRequerimientos", param: new { fecIni = fecIni, fecFin = fecFin, empresa = empresa }, commandType: CommandType.StoredProcedure);
        }
        public async Task<IEnumerable<dynamic>> GetRequerimiento(string nroreq, int empresa)
        {
            using var connection = new SqlConnection(ConnectionString);
            return await connection.QueryAsync("usp_GetRequerimiento", param: new { nroreq = nroreq, empresa = empresa }, commandType: CommandType.StoredProcedure);
        }
        public async Task<IEnumerable<dynamic>> GetRequerimientoDetalle(string idReq)
        {
            using var connection = new SqlConnection(ConnectionString);
            return await connection.QueryAsync("usp_GetRequerimientoDetalle", param: new { idReq = idReq }, commandType: CommandType.StoredProcedure);
        }
        public async Task<IEnumerable<dynamic>> GetTrazabilidadDetalle(string idReq)
        {
            using var connection = new SqlConnection(ConnectionString);
            return await connection.QueryAsync("usp_GetTrazabilidadDetalle", param: new { idReq = idReq }, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<dynamic>> getOrdenCompra(DateTime fecIni, DateTime fecFin, int empresa)
        {
            using var connection = new SqlConnection(ConnectionString);
            return await connection.QueryAsync("usp_GetOrdenCompra", param: new { fecIni = fecIni, fecFin = fecFin, empresa = empresa }, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<dynamic>> getOCompra(string nroreq, int empresa)
        {
            using var connection = new SqlConnection(ConnectionString);
            return await connection.QueryAsync("usp_GetOCompra", param: new { nroreq = nroreq, empresa= empresa }, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<dynamic>> getOrdenCompraDetalle(string id)
        {
            using var connection = new SqlConnection(ConnectionString);
            return await connection.QueryAsync("usp_GetOrdenCompraDetalle", param: new { id = id }, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<dynamic>> getAgenda(string nroOrden)
        {
            using var connection = new SqlConnection(ConnectionString2);
            return await connection.QueryAsync("usp_GetAgenda", param: new { nroOrden = nroOrden }, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<dynamic>> getOCDetalleAgenda(string idOrdenC, string ruc)
        {
            using var connection = new SqlConnection(ConnectionString);
            return await connection.QueryAsync("usp_GetOCDetalleAgenda", param: new { idOrdenC = idOrdenC, ruc = ruc }, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<dynamic>> getPartesEntrada(DateTime fecIni, DateTime fecFin, int empresa)
        {
            using var connection = new SqlConnection(ConnectionString);
            return await connection.QueryAsync("usp_GetPartesEntrada", param: new { fecIni = fecIni, fecFin = fecFin, empresa = empresa }, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<dynamic>> getParteEntrada(string nroreq, int empresa)
        {
            using var connection = new SqlConnection(ConnectionString);
            return await connection.QueryAsync("usp_GetParteEntrada", param: new { nroreq = nroreq, empresa = empresa }, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<dynamic>> getPartesEntradaDetalle(string id)
        {
            using var connection = new SqlConnection(ConnectionString);
            return await connection.QueryAsync("usp_GetPartesEntradaDetalle", param: new { id = id }, commandType: CommandType.StoredProcedure);
        }
    }
}
