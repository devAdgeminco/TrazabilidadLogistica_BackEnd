using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface ICodigoBarrasRepository
    {
        Task<IEnumerable<dynamic>> GetBarraCodigoOC(string codigo, int empresa);
        Task<IEnumerable<dynamic>> GetBarraCodigoOCD(string codigo, int empresa);
    }
}
