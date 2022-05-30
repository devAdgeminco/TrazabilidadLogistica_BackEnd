using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IProveedorRepository
    {
        Task<IEnumerable<dynamic>> InsertAgendaDate(int id, string orden, string fechaAgenda);
        Task<IEnumerable<dynamic>> InsertAgendaDetalle(int idAgenda, string codProducto, decimal cantidad);

    }
}
