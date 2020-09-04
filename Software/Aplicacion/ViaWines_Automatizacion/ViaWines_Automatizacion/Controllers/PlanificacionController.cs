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
        public JsonResult AgregarOrdenesNuevas(int OrdenFabricacion, String Fecha)
        {
            //String fecha = DateTime.Today.ToString("yyyy-MM-dd");
            //int cantOrdenesActuales = 0;
            //int cantOrdenesNuevas = 0;

            //List<Orden> ordenesActuales = ConsultaPlanificacion.LeerOrdenes(fecha, 1);
            return Json(ConsultaPlanificacion.AgregarNuevasOrdenes(OrdenFabricacion, Fecha));
            //List<Orden> ordenesNuevas = ConsultaPlanificacion.LeerOrdenes(fecha, 1);

            /*if (ordenesActuales != null)
            {
                cantOrdenesActuales = ordenesActuales.Count();
            }

            if (ordenesNuevas != null)
            {
                cantOrdenesNuevas = ordenesNuevas.Count();
            }

            if (cantOrdenesNuevas > cantOrdenesActuales)
            {
                return true;
            }
            return false;*/
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
                    fechasAux = ConsultaPlanificacion.LeerFechasOrdenesAbiertas();
                    break;
                case 2:
                    /*Fechas de ordenes Planificadas (futuras)*/
                    fechasAux = ConsultaPlanificacion.LeerFechasOrdenesPlanificadas();
                    break;
                default:
                    /*Todas las fechas en donde existen ordenes*/
                    List<String> fechasPasadas = ConsultaPlanificacion.LeerFechasPasadas();
                    List<String> fechas = ConsultaPlanificacion.LeerFechas();
                    fechasAux = fechasPasadas.Union(fechas).ToList();
                    break;
            }

            if (fechasAux != null)
            {
                return Json(fechasAux);
            }
            return Json(new object());
        }










        /*[HttpGet]
        public JsonResult GetTodasFechasPlanificacion()
        {
            List<String> fechasPasadas = ConsultaPlanificacion.LeerFechasPasadas();
            List<String> fechas = ConsultaPlanificacion.LeerFechas();

            List<String> fechasAux = fechasPasadas.Union(fechas).ToList();
            if (fechasAux != null)
            {
                return Json(fechasAux);
            }
            return Json(new object());
        }

        [HttpGet]
        public JsonResult GetFechasOrdenesPlanificadas()
        {
            List<String> fechasOrden = ConsultaPlanificacion.LeerFechasOrdenesPlanificadas();
            if (fechasOrden != null)
            {
                return Json(fechasOrden);
            }
            return Json(new object());
        }

        [HttpGet]
        public JsonResult GetFechaOrdenesAbiertas()
        {
            List<String> fechasOrden = ConsultaPlanificacion.LeerFechasOrdenesAbiertas();
            if (fechasOrden != null)
            {
                return Json(fechasOrden);
            }
            return Json(new object());
        }*/
    }
}