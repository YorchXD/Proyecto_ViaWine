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
            //String fecha = "2020-06-04";
            String fecha = DateTime.Now.ToString("yyyy-MM-dd");
            List<Orden> ordenes = ConsultaResumen.LeerOrdenes(fecha);
            return View(ordenes);
        }


        [HttpPost]
        /*public JsonResult GetCantCajas(int OrdenFabricacion, int CajasPlanificadas)
        {
            //String fecha = "2020-06-04";
            String fecha = DateTime.Now.ToString("yyyy-MM-dd");
            int cantCajas = ConsultaResumen.LeerCantCajas(fecha, OrdenFabricacion);
            double porcentaje;

            if(cantCajas == -1)
            {
                cantCajas = 0;
            }

            porcentaje = (double)((cantCajas * 100.0) / CajasPlanificadas);

            var datosCaja = new
            {
                CantCajas = cantCajas,
                Porcentaje = Math.Round(porcentaje, 2)
            };

            return Json(datosCaja);
        }

        [HttpPost]
        public JsonResult GetCantBotellas(int OrdenFabricacion, int BotellasPlanificadas)
        {
            //String fecha = "2020-06-04";
            String fecha = DateTime.Now.ToString("yyyy-MM-dd");
            int cantBotellas = ConsultaResumen.LeerCantBotellas(fecha, OrdenFabricacion);
            double porcentaje;
            if (cantBotellas == -1)
            {
                cantBotellas = 0;
            }

            porcentaje = (double)((cantBotellas * 100.0) / BotellasPlanificadas);

            var datosBotella = new
            {
                CantBotellas = cantBotellas,
                Porcentaje = Math.Round(porcentaje, 2)
            };
            return Json(datosBotella);
        }

        [HttpPost]
        public JsonResult GetVelocidad(int OrdenFabricacion)
        {
            //String fecha = "2020-06-04";
            String fecha = DateTime.Now.ToString("yyyy-MM-dd");
            String hora = DateTime.Now.AddMinutes(-1).ToString("HH:mm");
            VelocidadProceso velocidad = ConsultaResumen.LeerVelocidad(fecha, hora, OrdenFabricacion);
            return Json(velocidad);
        }*/

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public JsonResult GetCantBotellasDia()
        {
            //String fecha = "2020-06-04";
            String fecha = DateTime.Now.ToString("yyyy-MM-dd");
            List<int> indicador = ConsultaResumen.LeerCantBotellasDia(fecha);
            double porcentaje;
            int cantBotellas;
            int total;
            if (indicador == null)
            {
                cantBotellas = 0;
                porcentaje = 0;
            }
            else
            {
                cantBotellas = indicador[0];
                total = indicador[1];
                if(total!=0)
                {
                    porcentaje = (double)((cantBotellas * 100.0) / total);
                }
                else
                {
                    porcentaje = 0;
                }
                
            }

            var datosBotella = new
            {
                CantBotellas = cantBotellas,
                Porcentaje = Math.Round(porcentaje, 2)
            };
            return Json(datosBotella);
        }

        [HttpPost]
        public JsonResult GetCantCajasDia()
        {
            //String fecha = "2020-06-04";
            String fecha = DateTime.Now.ToString("yyyy-MM-dd");
            List<int> indicador = ConsultaResumen.LeerCantCajasDia(fecha);
            double porcentaje;
            int cantCajas;
            int total;
            if (indicador == null)
            {
                cantCajas = 0;
                porcentaje = 0;
            }
            else
            {
                cantCajas = indicador[0];
                total = indicador[1];
                if (total != 0)
                {
                    porcentaje = (double)((cantCajas * 100.0) / total);
                }
                else
                {
                    porcentaje = 0;
                }
                
            }

            var datosCajas = new
            {
                CantCajas = cantCajas,
                Porcentaje = Math.Round(porcentaje, 2)
            };
            return Json(datosCajas);
        }

        [HttpPost]
        public JsonResult GetCantOrdenesDia()
        {
            //String fecha = "2020-06-04";
            String fecha = DateTime.Now.ToString("yyyy-MM-dd");
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
        public JsonResult getOrdenes()
        {
            //String fecha = "2020-06-04";
            String fecha = DateTime.Now.ToString("yyyy-MM-dd");
            List<Orden> ordenes = ConsultaResumen.LeerOrdenes(fecha);
            if(ordenes!=null)
            {
                return Json(ordenes);
            }
            return Json(new Object());
        }

        [HttpPost]
        public JsonResult GetMonitoreoMateriales(int OrdenFabricacion)
        {
            String fecha = DateTime.Now.ToString("yyyy-MM-dd");
            List<Material> materiales = ConsultaResumen.LeerMaterial(fecha, OrdenFabricacion);
            if (materiales != null)
            {
                return Json(materiales);
            }
            /*Manda un objeto vacio para que se active zero records y muestre que no hay información en la tabla*/
            return Json(new Object());
        }

        [HttpPost]
        public JsonResult GetVelocidadPorMin(int OrdenFabricacion, string TipoMaterial)
        {
            //String fecha = "2020-05-13";
            String fecha = DateTime.Now.ToString("yyyy-MM-dd");
            String hora = DateTime.Now.AddMinutes(-1).ToString("HH:mm");
            int cantTpoMaterial = ConsultaResumen.LeerVelocidadMaterial(fecha, hora, OrdenFabricacion, TipoMaterial);
            if (cantTpoMaterial == -1)
            {
                cantTpoMaterial = 0;
            }
            return Json(cantTpoMaterial);
        }


        /*public JsonResult getIndicadorAvanceDia()
        {
            String fecha = DateTime.Now.ToString("yyyy-MM-dd");
            List<Objeto> listaBotellasHoras = ConsultaResumen.LeerCantBotellasHora(fecha);
            int CantBotellas = 0;
            for(int i =0; i< listaBotellasHoras.Count(); i++)
            {
                CantBotellas += listaBotellasHoras[i].Cantidad;
            }

            return Json(CantBotellas);

        }*/


        /*[HttpPost]
        public JsonResult GetVelocidadBotellas(int OrdenFabricacion)
        {
            //String fecha = "2020-05-13";
            String fecha = DateTime.Now.ToString("yyyy-MM-dd");
            String hora = DateTime.Now.AddMinutes(-1).ToString("HH:mm");
            int cantBotellas = ConsultaProceso.LeerVelocidadBotellas(fecha, hora, OrdenFabricacion);
            if (cantBotellas == -1)
            {
                cantBotellas = 0;
            }
            return Json(cantBotellas);
        }

        [HttpPost]
        public JsonResult GetVelocidadCajas(int OrdenFabricacion)
        {
            //String fecha = "2020-05-13";
            String fecha = DateTime.Now.ToString("yyyy-MM-dd");
            String hora = DateTime.Now.AddMinutes(-1).ToString("HH:mm");
            int cantCajas = ConsultaProceso.LeerVelocidadCajas(fecha, hora, OrdenFabricacion);
            if (cantCajas == -1)
            {
                cantCajas = 0;
            }
            return Json(cantCajas);
        }*/
    }
}