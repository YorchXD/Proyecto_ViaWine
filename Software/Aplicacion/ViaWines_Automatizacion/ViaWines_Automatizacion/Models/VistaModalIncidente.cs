using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ViaWines_Automatizacion.Models
{
    public class VistaModalIncidente
    {
        public String Titulo { get; set; }
        public String Contenido { get; set; }
        public Boolean RegistroExitoso { get; set; }
        public int IdIncidente { get; set; }
    }
}
