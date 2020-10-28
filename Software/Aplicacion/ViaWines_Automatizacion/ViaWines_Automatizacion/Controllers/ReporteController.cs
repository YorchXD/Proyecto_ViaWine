using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ViaWines_Automatizacion.DbAutomatizacionViaWines;
using ViaWines_Automatizacion.Filtros;
using ViaWines_Automatizacion.Models;

namespace ViaWines_Automatizacion.Controllers
{
    public class ReporteController : Controller
    {
        [PermisosUsuario(idOperacion: 10)]
        public IActionResult Reporte()
        {
            return View();
        }

        [HttpPost]
        public JsonResult ObtenerFechaIncidentes()
        {
            List<String> fechasIncidente = ConsultaReporte.LeerFechasIncidentes();
            if (fechasIncidente != null)
            {

                return Json(fechasIncidente);
            }
            return Json(new object());
        }

        [HttpPost]
        public JsonResult Reporte(int Opcion, String Fecha, int Semana, int Mes, int Anio)
        {
            Boolean validar = false;
            List<Area> areas = ConsultaReporte.Reporte(Opcion, Fecha, Semana, Mes, Anio);
            if(areas!=null)
            {
                validar = true;
            }

            var datos = new
            {
                validar = validar,
                areas = areas
            };
            return Json(datos);
        }

        [HttpPost]
        public JsonResult Filtro(int Opcion, int Anio, int Mes)
        {
            Boolean validar = false;
            List<FiltroReporte> filtros = ConsultaReporte.FiltroReporte(Opcion, Anio, Mes);
            if (filtros != null)
            {
                validar = true;
            }

            var datos = new
            {
                validar = validar,
                fittros = filtros
            };
            return Json(datos);
        }

        [HttpPost]
        public JsonResult Indicadores(int Opcion, String Dia, int Anio, int Mes, int Semana)
        {
            Boolean validar = false;
            List<int> indicadores = ConsultaReporte.Indicadores(Dia, Anio, Mes, Semana, Opcion);
            if (indicadores.Count != 0)
            {
                validar = true;
            }

            var datos = new
            {
                validar = validar,
                cantOrdenesPlan = indicadores[0],
                cantOrdenesNoIni = indicadores[1],
                cantOrdenesPausadas = indicadores[2],
                cantOrdenesPospuestas = indicadores[3],
                cantOrdenesFinalizadas = indicadores[4],
            };
            return Json(datos);
        }
    }
}
