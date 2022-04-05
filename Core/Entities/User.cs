using System;

namespace Core.Entities
{
    public class User
    {
        public int CodUsuario { get; set; }
        public string Login { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string NombreCompleto { get; set; }
        public int CodEmpresa { get; set; }
        public string TipoUsuarioMa { get; set; }
        public string Clave { get; set; }
        public bool ActivoLogueo { get; set; }
        public bool Activo { get; set; }
        public int CodUsuarioIngreso { get; set; }
        public DateTime FechaIngreso { get; set; }
        public int CodUsuarioActualizacion { get; set; }
        public DateTime FechaActualizacion { get; set; }


    }
}
