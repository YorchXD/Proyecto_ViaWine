using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ViaWines_Automatizacion.DbAutomatizacionViaWines;
using ViaWines_Automatizacion.Models;

namespace ViaWines_Automatizacion.Controllers
{
    public class ProcesoController : Controller
    {
        public IActionResult Proceso(DateTime fecha)
        {
            List<Orden> ordenes;
            if (fecha.ToString("yyyy-MM-dd").Equals("0001-01-01"))
            {
                //ordenes = ConsultaPlanificacion.LeerOrdenes("2020-02-17");
                ordenes = ConsultaPlanificacion.LeerOrdenes(DateTime.Now.ToString("yyyy-MM-dd"));
            }
            else
            {
                ordenes = ConsultaPlanificacion.LeerOrdenes(fecha.ToString("yyyy-MM-dd"));
            }

            return View(ordenes);
        }

        [HttpPost]
        public JsonResult Proceso(int Orden, int Estado, string Fecha)//ActualizarOrden orden)
        {
            int actualizacion = ConsultaProceso.ActualizarEstadoOrden(Orden, Estado);
            //int actualizacion = -1;
            if(actualizacion==1)
            {
                return Json(true);
            }
            return Json(false);
        }

        [HttpPost]
        public JsonResult Exit_proces_ini()//ActualizarOrden orden)
        {
            var resultado = new VistaModalIniciarProceso();
            
            List<Orden> ordenes = ConsultaProceso.LeerOrdenesIniciadas();
            //int actualizacion = -1;
            if (ordenes.Count>0)
            {
                resultado.Titulo = "Falló iniciar proceso";
                resultado.Contenido = "No se puede iniciar proceso dado que existe otro ejecutandose";
                resultado.ExisteProceso = true;
            }
            else
            {
                resultado.Titulo = "Falló iniciar proceso";
                resultado.Contenido = "No se puede iniciar proceso dado que existe otro ejecutandose";
                resultado.ExisteProceso = false;
            }
            return Json(resultado);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}