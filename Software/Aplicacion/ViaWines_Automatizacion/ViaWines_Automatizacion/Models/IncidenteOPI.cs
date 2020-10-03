using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ViaWines_Automatizacion.Models
{
    public class IncidenteOPI
    {
        public int CodigoCorto { get; set; }
        public String CodigoLargo { get; set; }
        public String Tiempo { get; set; }
        public String Clasificacion { get; set; }
        public String Aclaracion { get; set; }
        public String Zona { get; set; }
        public int CantIncidentes { get; set; }
    }
}
