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
    public class ProveedorRepository: IProveedorRepository
    {
        private readonly string ConnectionString;
        private readonly string ConnectionString2;
        public ProveedorRepository(IConfiguration configuration)
        {
            ConnectionString = ConfigurationExtensions.GetConnectionString(configuration, "BDAgenda");

            ConnectionString2 = ConfigurationExtensions.GetConnectionString(configuration, "BDADGintegra");
        }

        public async Task<IEnumerable<dynamic>> InsertAgendaDate(int id, string orden, string RucProv, string RazonSocial, string DetalleOC, string fechaAgenda)
        {
            using var connection = new SqlConnection(ConnectionString);
            return await connection.QueryAsync("usp_InsertAgendaDate", param: new { id = id, orden = orden, RucProv = RucProv, RazonSocial = RazonSocial, DetalleOC = DetalleOC, fechaAgenda = fechaAgenda   }, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<dynamic>> InsertAgendaDetalle(int idAgenda, string codProducto, decimal cantidad)
        {
            using var connection = new SqlConnection(ConnectionString);
            return await connection.QueryAsync("usp_InsertAgendaDetalle", param: new { idAgenda = idAgenda, codProducto = codProducto, cantidad = cantidad }, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<dynamic>> GetAgendaAll()
        {
            using var connection = new SqlConnection(ConnectionString);
            return await connection.QueryAsync("usp_GetAgendaAll", commandType: CommandType.StoredProcedure);
        }
        public async Task<IEnumerable<dynamic>> GetAgendaDetalle(int id)
        {
            using var connection = new SqlConnection(ConnectionString2);
            return await connection.QueryAsync("usp_getAgendaDetalle", param: new { id = id }, commandType: CommandType.StoredProcedure);
        }
        public async Task<IEnumerable<dynamic>> SetAprobacionAgenda(int id, bool value)
        {
            using var connection = new SqlConnection(ConnectionString);
            return await connection.QueryAsync("usp_setAprobacionAgenda", param: new { id = id, value = value }, commandType: CommandType.StoredProcedure);
        }
    }
}
