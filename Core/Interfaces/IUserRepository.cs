using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<dynamic>> GetUsers();
        Task<IEnumerable<dynamic>> GetUser(string login, string CodEmpresa);
        Task<IEnumerable<dynamic>> GetUserForm(int CodUsuario);
        Task<IEnumerable<dynamic>> GetModulos(int CodUsuario);
        Task<IEnumerable<dynamic>> GetPerfiles();
        Task<IEnumerable<dynamic>> InsertUser(string Login, string Nombres, string Apellidos, int CodEmpresa, string TipoUsuarioMa, string Clave, int CodUsuarioEvento);
        Task<IEnumerable<dynamic>> UpdateUser(int CodUsuario, string Login, string Nombres, string Apellidos, int CodEmpresa, string TipoUsuarioMa, int CodUsuarioEvento);
        Task<IEnumerable<dynamic>> DeleteUser(int CodUsuario, int CodUsuarioEvento);
        Task<IEnumerable<dynamic>> UpdatePswdUser(int CodUsuario, string Clave);

    }
}
