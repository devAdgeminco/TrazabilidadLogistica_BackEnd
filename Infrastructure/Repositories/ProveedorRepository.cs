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
        public ProveedorRepository(IConfiguration configuration)
        {
            ConnectionString = ConfigurationExtensions.GetConnectionString(configuration, "BDAgenda");
        }

        public async Task<IEnumerable<dynamic>> InsertAgendaDate(int id, string orden, string fechaAgenda)
        {
            using var connection = new SqlConnection(ConnectionString);
            return await connection.QueryAsync("usp_InsertAgendaDate", param: new { id = id, orden = orden, fechaAgenda = fechaAgenda }, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<dynamic>> InsertAgendaDetalle(int idAgenda, string codProducto, decimal cantidad)
        {
            using var connection = new SqlConnection(ConnectionString);
            return await connection.QueryAsync("usp_InsertAgendaDetalle", param: new { idAgenda = idAgenda, codProducto = codProducto, cantidad = cantidad }, commandType: CommandType.StoredProcedure);
        }
    }
}
