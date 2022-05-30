using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public class AgendaDetalle
    {

        public int id { get; set; }
        public int idAgenda { get; set; }
        public string codProducto { get; set; }
        public decimal cantidad { get; set; }

    }
}
