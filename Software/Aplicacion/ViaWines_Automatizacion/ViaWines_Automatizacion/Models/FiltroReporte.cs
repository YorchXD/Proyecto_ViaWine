using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ViaWines_Automatizacion.Models
{
    public class FiltroReporte
    {
        public int Anio { get; set; }
        public int Mes { get; set; }
        public int Semana { get; set; }
        public DateTime IniSemana { get; set; }
        public DateTime FinSemana { get; set; }
    }
}
