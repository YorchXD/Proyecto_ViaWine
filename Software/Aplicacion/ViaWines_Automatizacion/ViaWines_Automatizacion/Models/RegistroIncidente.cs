using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ViaWines_Automatizacion.Models
{
    public class RegistroIncidente
    {
        public int Id { get; set; }
        public String NombreArea { get; set; }
        public int RefOrden { get; set; }
        public DateTime FechaHoraInicio { get; set; }
        public DateTime FechaHoraTermino { get; set; }
        public String Observacion { get; set; }
        public String EstadoOrden { get; set; }
        public double ProgresoOrden { get; set; }
        public int CantMinutos {get; set;}
    }
}
