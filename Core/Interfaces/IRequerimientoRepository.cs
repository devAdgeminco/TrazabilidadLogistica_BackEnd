using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IRequerimientoRepository
    {
        Task<IEnumerable<dynamic>> GetRequerimientos(DateTime fecIni, DateTime fecFin);
        Task<IEnumerable<dynamic>> GetRequerimientoDetalle(string idReq);
    }
}
