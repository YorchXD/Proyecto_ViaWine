using System;

namespace ViaWines_Automatizacion.Models
{
    public class Incidente
    {
        public int IdIncidente { get; set; }
        public String IdAgrupacionTiempo { get; set; }
        public String NombreAgrupacionTiempo { get; set; }
        public String IdClasificacion { get; set; }
        public String DescripcionClasificacion { get; set; }
        public String AclaracionClasificacion { get; set; }
        public String ReqObservacion { get; set; }
        public String IdZona { get; set; }
        public String NombreZona { get; set; }
    }
}
