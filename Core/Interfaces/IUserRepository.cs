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
    }
}
