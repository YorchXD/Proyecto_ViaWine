using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ViaWines_Automatizacion.Models;
using ViaWines_Automatizacion.DbAutomatizacionViaWines;
using System.ComponentModel.DataAnnotations;
using ViaWines_Automatizacion.Filtros;

namespace ViaWines_Automatizacion.Controllers
{
    
    public class PlanificacionController : Controller
    {
        [PermisosUsuario(idOperacion: 3)]
        public IActionResult Planificacion()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [PermisosUsuario(idOperacion: 2)]
        [HttpPost]
        public JsonResult AgregarOrdenesNuevas(int OrdenFabricacion, String Fecha)
        {
            return Json(ConsultaPlanificacion.AgregarNuevasOrdenes(OrdenFabricacion, Fecha));
        }

        [HttpPost]
        public JsonResult LeerPlanificaciones(String fecha, int opcion)
        {
            bool validacion = true;
            List<Orden> ordenes = ConsultaPlanificacion.LeerOrdenes(fecha, opcion);
            /*Manda un objeto vacio para que se active zero records y muestre que no hay información en la tabla*/
            if (ordenes==null)
            {
                ordenes = new List<Orden>();
                validacion = false;
            }

            var planificacion = new
            {
                validacion = validacion,
                ordenes = ordenes
            };

            
            return Json(planificacion);
            
        }

        [HttpPost]
        public JsonResult GetFechasTipo(int opcion)
        {
            List<String> fechasAux = null;
            switch (opcion)
            {
                case 1:
                    /*Fecha de ordenes abiertas*/
                    fechasAux = ConsultaPlanificacion.FechasOrdenes(3);
                    //fechasAux = ConsultaPlanificacion.LeerFechasOrdenesAbiertas();
                    break;
                case 2:
                    /*Fechas de ordenes Planificadas (futuras)*/
                    fechasAux = ConsultaPlanificacion.FechasOrdenes(1);
                    //fechasAux = ConsultaPlanificacion.LeerFechasOrdenesPlanificadas();
                    break;
                default:
                    /*Todas las fechas en donde existen ordenes*/
                    //List<String> fechasPasadas = ConsultaPlanificacion.LeerFechasPasadas();
                    //List<String> fechas = ConsultaPlanificacion.LeerFechas();
                    List<String> fechasPasadas = ConsultaPlanificacion.FechasOrdenes(4);
                    List<String> fechas = ConsultaPlanificacion.FechasOrdenes(2);
                    fechasAux = fechasPasadas.Union(fechas).ToList();
                    break;
            }

            if (fechasAux != null)
            {
                return Json(fechasAux);
            }
            return Json(new object());
        }
    }
}