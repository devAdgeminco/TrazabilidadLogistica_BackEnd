using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface ICompanyRepository
    {
        Task<IEnumerable<dynamic>> GetCompanies();
        Task<IEnumerable<dynamic>> ValidarEmpresaOC(string ruc);
    }
}
