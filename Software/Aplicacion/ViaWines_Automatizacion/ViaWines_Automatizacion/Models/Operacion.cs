using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ViaWines_Automatizacion.Models
{
    public class Operacion
    {
        public int Id { get; set; }
        public String Nombre { get; set; }
        public int IdControlador { get; set; }
    }
}
