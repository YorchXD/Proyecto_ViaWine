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
    public class ResumenController : Controller
    {
        public IActionResult Resumen()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetFechasOrdenes()
        {
            List<String> fechasOrden = ConsultaResumen.LeerFechasOrdenes();
            if (fechasOrden != null)
            {
                return Json(fechasOrden);
            }
            return Json(new object());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        /**
         * fecha: indica la fecha a consultar la cantidad de material
         * tipo indica si es botella (1) o caja(2)
         * */
        [HttpPost]
        public JsonResult GetCantMaterialDia(String Fecha, String Tipo)
        {
            List<int> indicador =  ConsultaResumen.LeerCantMaterialDia(Fecha, Tipo);

            double porcentaje = 0;
            int cantMaterial = 0;
            if (indicador != null)
            {
                cantMaterial = indicador[0];
                int total = indicador[1];
                if (total != 0)
                {
                    porcentaje = (double)((cantMaterial * 100.0) / total);
                }
                else
                {
                    porcentaje = 0;
                }

            }

            var datosCajas = new
            {
                CantMaterial = cantMaterial,
                Porcentaje = Math.Round(porcentaje, 2)
            };
            return Json(datosCajas);
        }

        /**
         * Obtiene la cantidad de ordenes finalizadas en un día en especifico
         */
        [HttpPost]
        public JsonResult GetCantOrdenesDia(String fecha)
        {
            //String fecha = "2020-06-04";
            //String fecha = DateTime.Now.ToString("yyyy-MM-dd");
            List<int> indicador = ConsultaResumen.LeerOrdenesTerminadasDia(fecha);
            double porcentaje;
            int cantOrdenes;
            int total;
            if (indicador == null)
            {
                cantOrdenes = 0;
                porcentaje = 0;
            }
            else
            {
                cantOrdenes = indicador[0];
                total = indicador[1];
                if(total!=0)
                {
                    porcentaje = (double)((cantOrdenes * 100.0) / total);
                }
                else
                {
                    porcentaje = 0;
                }
                
            }

            var datosOrdenes = new
            {
                CantOrdenes = cantOrdenes,
                Porcentaje = Math.Round(porcentaje, 2)
            };
            return Json(datosOrdenes);
        }

        [HttpPost]
        public JsonResult getOrdenes(String fecha)
        {
            List<Orden> ordenes = ConsultaResumen.LeerOrdenes(fecha);
            if(ordenes!=null)
            {
                return Json(ordenes);
            }
            return Json(new Object());
        }

        [HttpPost]
        public JsonResult GetMonitoreoMateriales(int OrdenFabricacion, String Fecha)
        {
            //String fecha = DateTime.Now.ToString("yyyy-MM-dd");
            List<Material> materiales = ConsultaResumen.LeerMaterial(Fecha, OrdenFabricacion);
            if (materiales != null)
            {
                return Json(materiales);
            }
            /*Manda un objeto vacio para que se active zero records y muestre que no hay información en la tabla*/
            return Json(new Object());
        }

        [HttpPost]
        public JsonResult GetVelocidadPorMin(int OrdenFabricacion, string TipoMaterial, String FechaFabricacion)
        {
            //String fecha = "2020-05-13";
            String FechaActual = DateTime.Now.ToString("yyyy-MM-dd");
            String Hora = DateTime.Now.AddMinutes(-1).ToString("HH:mm");
            int cantTpoMaterial = ConsultaResumen.LeerVelocidadMaterial(FechaActual, FechaFabricacion, Hora, OrdenFabricacion, TipoMaterial);
            if (cantTpoMaterial == -1)
            {
                cantTpoMaterial = 0;
            }
            return Json(cantTpoMaterial);
        }

        [HttpGet]
        public JsonResult GetMonitoreo(String Fecha, int OrdenFabricacion)
        {
            List<Monitoreo> monitoreo = ConsultaResumen.LeerMonitoreo(Fecha, OrdenFabricacion);
            if (monitoreo != null)
            {
                return Json(monitoreo);
            }
            return Json(new object());
        }

        [HttpPost]
        public JsonResult LeerPlanificaciones(String fecha)
        {
            List<Orden> ordenes = ConsultaResumen.LeerOrdenes(fecha);
            if (ordenes != null)
            {
                return Json(ordenes);
            }
            /*Manda un objeto vacio para que se active zero records y muestre que no hay información en la tabla*/
            return Json(new object());

        }
    }
}