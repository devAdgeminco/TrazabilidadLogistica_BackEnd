using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public class UserAgenda
    {

        public int id { get; set; }
        public string usuario { get; set; }
        public string clave { get; set; }
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public string rucEmpresa { get; set; }
        public string email { get; set; }
        public int validado { get; set; }
        public bool activo { get; set; }

    }
}
