using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Timers;

namespace ViaWines_Automatizacion.Models
{
    public class Orden
    {
        public int OrdenFabricacion { get; set; }
        public string Version { get; set; }
        public string Cliente { get; set; }
        public string SKU { get; set; }
        public string Descripcion { get; set; }
        public int BotellasPlanificadas { get; set; }
        public int CajasPlanificadas { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FechaFabricacion { get; set; }
        [DisplayFormat(DataFormatString = "{0:HH:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime HoraInicioPlanificada { get; set; }
        [DisplayFormat(DataFormatString = "{0:HH:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime HoraTerminoPlanificada { get; set; }
        [DisplayFormat(DataFormatString = "{0:HH:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime HoraInicio { get; set; }
        [DisplayFormat(DataFormatString = "{0:HH:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime HoraTermino { get; set; }
        public String FormatoCaja { get; set; }
        public int Estado { get; set; }
        public int Secuencia { get; set; }
    }
}
