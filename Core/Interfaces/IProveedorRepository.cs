using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IProveedorRepository
    {
        Task<IEnumerable<dynamic>> InsertAgendaDate(int id, string orden,string RucProv, string RazonSocial, string DetalleOC, string fechaAgenda);
        Task<IEnumerable<dynamic>> InsertAgendaDetalle(int idAgenda, string codProducto, decimal cantidad);
        Task<IEnumerable<dynamic>> GetAgendaAll();
        Task<IEnumerable<dynamic>> GetAgendaDetalle(int id);
        Task<IEnumerable<dynamic>> SetAprobacionAgenda(int id, bool value);
    }
}
