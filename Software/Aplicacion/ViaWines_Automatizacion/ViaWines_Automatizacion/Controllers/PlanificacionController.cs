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


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public JsonResult GetPlanificacion(String fecha, int opcion)
        {
            List<Orden> ordenes = ConsultaPlanificacion.LeerOrdenes(fecha, opcion); 
            if (ordenes!=null)
            {
                return Json(ordenes);
            }
            /*Manda un objeto vacio para que se active zero records y muestre que no hay información en la tabla*/
            return Json(new object());
            
        }

        [HttpGet]
        public JsonResult GetFechasPlanificacion()
        {
            List<String> fechas = ConsultaPlanificacion.LeerFechas();
            if(fechas!=null)
            {
                return Json(fechas);
            }
            return Json(new object());
            
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