using Core.Entities;
using Dapper;
using Core.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data;
using System;

namespace Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly string ConnectionString;
        public UserRepository(IConfiguration configuration)
        {
            ConnectionString = ConfigurationExtensions.GetConnectionString(configuration, "BDADGintegra");
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
        public async Task<IEnumerable<dynamic>> GetUserForm(int CodUsuario)
        {
            using var connection = new SqlConnection(ConnectionString);
            return await connection.QueryAsync("usp_Usuario_Get", param: new { CodUsuario = CodUsuario }, commandType: CommandType.StoredProcedure);
        }
        public async Task<IEnumerable<dynamic>> GetModulos(int CodUsuario)
        {
            using var connection = new SqlConnection(ConnectionString);
            return await connection.QueryAsync("usp_ModuloUsuario", param: new { CodUsuario = CodUsuario }, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<dynamic>> GetPerfiles()
        {
            using var connection = new SqlConnection(ConnectionString);
            return await connection.QueryAsync("usp_GetPerfiles", commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<dynamic>> InsertUser(string Login, string Nombres, string Apellidos, int CodEmpresa, string TipoUsuarioMa, string Clave, int CodUsuarioEvento)
        {
            using var connection = new SqlConnection(ConnectionString);
            return await connection.QueryAsync("usp_Usuario_Ins", param: new {
                Login = Login,
                Nombres = Nombres,
                Apellidos = Apellidos,
                NombreCompleto = Nombres + " " + Apellidos,
                CodEmpresa = CodEmpresa,
                TipoUsuarioMa = TipoUsuarioMa,
                Clave = Clave,
                ActivoLogueo = 0,
                CodUsuarioEvento = CodUsuarioEvento,
                FechaEvento = DateTime.Now,

            }, commandType: CommandType.StoredProcedure);
        }
        public async Task<IEnumerable<dynamic>> UpdateUser(int CodUsuario, string Login, string Nombres, string Apellidos, int CodEmpresa, string TipoUsuarioMa, int CodUsuarioEvento)
        {
            using var connection = new SqlConnection(ConnectionString);
            return await connection.QueryAsync("usp_Usuario_Upd", param: new
            {
                CodUsuario = CodUsuario,
                Login = Login,
                Nombres = Nombres,
                Apellidos = Apellidos,
                NombreCompleto = Nombres + " " + Apellidos,
                CodEmpresa = CodEmpresa,
                TipoUsuarioMa = TipoUsuarioMa,
                ActivoLogueo = 0,
                CodUsuarioEvento = CodUsuarioEvento,
                FechaEvento = DateTime.Now,

            }, commandType: CommandType.StoredProcedure);
        }
        public async Task<IEnumerable<dynamic>> DeleteUser(int CodUsuario, int CodUsuarioEvento)
        {
            using var connection = new SqlConnection(ConnectionString);
            return await connection.QueryAsync("usp_Usuario_Del", param: new
            {
                CodUsuario = CodUsuario,
                CodUsuarioEvento = CodUsuarioEvento,
                FechaEvento = DateTime.Now,
            }, commandType: CommandType.StoredProcedure);
        }
        public async Task<IEnumerable<dynamic>> UpdatePswdUser(int CodUsuario, string Clave)
        {
            using var connection = new SqlConnection(ConnectionString);
            return await connection.QueryAsync("usp_Usuario_Upd_Clave", param: new
            {
                CodUsuario = CodUsuario,
                Clave = Clave
            }, commandType: CommandType.StoredProcedure);
        }
    }
}
