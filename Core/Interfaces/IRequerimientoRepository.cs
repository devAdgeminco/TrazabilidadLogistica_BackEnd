﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IRequerimientoRepository
    {
        Task<IEnumerable<dynamic>> GetRequerimientos(DateTime fecIni, DateTime fecFin);
        Task<IEnumerable<dynamic>> GetRequerimientoDetalle(string idReq);
        Task<IEnumerable<dynamic>> getOrdenCompra(DateTime fecIni, DateTime fecFin);
        Task<IEnumerable<dynamic>> getOrdenCompraDetalle(string id);
        Task<IEnumerable<dynamic>> getPartesEntrada(DateTime fecIni, DateTime fecFin);
        Task<IEnumerable<dynamic>> getPartesEntradaDetalle(string id);
    }
}