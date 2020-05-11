using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ViaWines_Automatizacion.Models;
using ViaWines_Automatizacion.DbAutomatizacionViaWines;
using System.ComponentModel.DataAnnotations;



namespace ViaWines_Automatizacion.Controllers
{
    public class PlanificacionController : Controller
    {
        public IActionResult Planificacion()
        {
            return View();
        }

        /*public IActionResult Planificacion(DateTime fecha)
        {
            List<Orden> ordenes;
            if (fecha.ToString("yyyy-MM-dd").Equals("0001-01-01"))
            {
                ordenes = ConsultaPlanificacion.LeerOrdenes(DateTime.Now.ToString("yyyy-MM-dd"));
            }
            else
            {
                ordenes = ConsultaPlanificacion.LeerOrdenes(fecha.ToString("yyyy-MM-dd"));
            }

            return View(ordenes);
        }*/


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public JsonResult GetPlanificacion(String fecha, int opcion)
        {
            List<Orden> ordenes = ConsultaPlanificacion.LeerOrdenes(fecha, opcion); 
            return Json(ordenes);
        }

        [HttpGet]
        public JsonResult GetFechasPlanificacion()
        {
            List<String> fechas = ConsultaPlanificacion.LeerFechas();
            return Json(fechas);
        }


        [HttpPost]
        public JsonResult Exit_proces_ini()//ActualizarOrden orden)
        {
            var resultado = new VistaModalIniciarProceso();

            List<Orden> ordenes = ConsultaProceso.LeerOrdenesIniciadas();
            //int actualizacion = -1;
            if (ordenes.Count > 0)
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
    }
}