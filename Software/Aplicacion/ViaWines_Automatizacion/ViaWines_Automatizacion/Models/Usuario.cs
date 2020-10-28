using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ViaWines_Automatizacion.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Nombre { get; set; }
        public int IdRol { get; set; }
        public string NombreRol { get; set; }
        public string Cargo { get; set; }

    }
}
