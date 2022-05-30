using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IRequerimientoRepository
    {
        Task<IEnumerable<dynamic>> GetRequerimientos(DateTime fecIni, DateTime fecFin, int empresa);
        Task<IEnumerable<dynamic>> GetRequerimiento(string nroreq, int empresa);
        Task<IEnumerable<dynamic>> GetRequerimientoDetalle(string idReq);
        Task<IEnumerable<dynamic>> GetTrazabilidadDetalle(string idReq);
        Task<IEnumerable<dynamic>> getOrdenCompra(DateTime fecIni, DateTime fecFin, int empresa);
        Task<IEnumerable<dynamic>> getOCompra(string nroreq, int empresa);
        Task<IEnumerable<dynamic>> getOrdenCompraDetalle(string id);
        Task<IEnumerable<dynamic>> getOCDetalleAgenda(string idOrdenC, string ruc);
        Task<IEnumerable<dynamic>> getAgenda(string nroOrden);
        Task<IEnumerable<dynamic>> getPartesEntrada(DateTime fecIni, DateTime fecFin, int empresa);
        Task<IEnumerable<dynamic>> getParteEntrada(string nroreq, int empresa);
        Task<IEnumerable<dynamic>> getPartesEntradaDetalle(string id);
    }
}
