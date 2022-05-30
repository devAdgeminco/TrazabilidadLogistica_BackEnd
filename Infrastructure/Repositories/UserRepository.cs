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
        private readonly string ConnectionString2;
        public UserRepository(IConfiguration configuration)
        {
            ConnectionString = ConfigurationExtensions.GetConnectionString(configuration, "BDADGintegra");
            ConnectionString2 = ConfigurationExtensions.GetConnectionString(configuration, "BDAgenda");
        }
        public async Task<IEnumerable<dynamic>> GetUsers()
        {
            using var connection = new SqlConnection(ConnectionString);
            return await connection.QueryAsync("sp_GetUsuarios", commandType: CommandType.StoredProcedure);
        }
        public async Task<IEnumerable<dynamic>> GetUsersAgenda()
        {
            using var connection = new SqlConnection(ConnectionString2);
            return await connection.QueryAsync("usp_GetUsuariosAgenda", commandType: CommandType.StoredProcedure);
        }
        public async Task<IEnumerable<dynamic>> GetUser(string login, string CodEmpresa)
        {
            using var connection = new SqlConnection(ConnectionString);
            return await connection.QueryAsync("usp_Usuario_ObtenerxLogin", param : new { Login = login, CodEmpresa = CodEmpresa },commandType: CommandType.StoredProcedure);
        }
        public async Task<IEnumerable<dynamic>> GetUserAgenda(string usuario)
        {
            using var connection = new SqlConnection(ConnectionString2);
            return await connection.QueryAsync("ssp_Login", param: new { usuario = usuario }, commandType: CommandType.StoredProcedure);
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

        public async Task<IEnumerable<dynamic>> InsertUserAgenda(string usuario, string clave, string nombres, string apellidos, string rucEmpresa, string email)
        {
            using var connection = new SqlConnection(ConnectionString2);
            return await connection.QueryAsync("usp_InsertUsuario", param: new
            {
                usuario = usuario,
                clave = clave,
                nombres = nombres,
                apellidos = apellidos,
                rucEmpresa = rucEmpresa,
                email = email
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
