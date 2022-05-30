using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public class Agenda
    {
        public int id { get; set; }
        public string orden { get; set; }
        public string fechaAgenda { get; set; }
        public bool Aprobacion { get; set; }
    }
}
