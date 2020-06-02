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
        public IActionResult Proceso()
        {
            String fecha = DateTime.Now.ToString("yyyy-MM-dd");
            List<Orden> ordenes = ConsultaProceso.LeerOrdenes(fecha);
            return View(ordenes);
        }

        [HttpPost]
        public JsonResult ActualizarEstadoProceso(int OrdenFabricacion, int Estado)//ActualizarOrden orden)
        {
            int actualizacion = ConsultaProceso.ActualizarEstadoOrden(OrdenFabricacion, Estado);
            if(actualizacion==1)
            {
                return Json(true);
            }
            return Json(false);
        }

        public Boolean OrdenesIniciadas(List<Orden> Ordenes)
        {
            for (int i = 0; i < Ordenes.Count; i++)
            {
                if (Ordenes[i].Estado==1)
                {
                    return true;
                }
            }
            return false;
        }
        public Boolean OrdenIniciada(List<Orden> Ordenes, int Orden)
        {
            for(int i=0; i<Ordenes.Count;i++)
            {
                if(Ordenes[i].OrdenFabricacion==Orden && Ordenes[i].Estado==1)
                {
                    return true;
                }
            }
            return false;
        }

        public Boolean OrdenPausada(List<Orden> Ordenes, int Orden)
        {
            for (int i = 0; i < Ordenes.Count; i++)
            {
                if (Ordenes[i].OrdenFabricacion == Orden && Ordenes[i].Estado == 2)
                {
                    return true;
                }
            }
            return false;
        }

        public Boolean OrdenPospuesta(List<Orden> Ordenes, int Orden)
        {
            for (int i = 0; i < Ordenes.Count; i++)
            {
                if (Ordenes[i].OrdenFabricacion == Orden && Ordenes[i].Estado == 3)
                {
                    return true;
                }
            }
            return false;
        }

        public Boolean OrdenFinalizada(List<Orden> Ordenes, int Orden)
        {
            for (int i = 0; i < Ordenes.Count; i++)
            {
                if (Ordenes[i].OrdenFabricacion == Orden && Ordenes[i].Estado == 4)
                {
                    return true;
                }
            }
            return false;
        }

        [HttpGet]
        public JsonResult Exit_proces_ini(int OpcionAccion, int OrdenFabricacion)//ActualizarOrden orden)
        {
            var resultado = new VistaModalIniciarProceso();
            String fecha = DateTime.Now.ToString("yyyy-MM-dd");
            List<Orden> Ordenes = ConsultaProceso.LeerOrdenes(fecha);
            Boolean ordenesIniciadas = OrdenesIniciadas(Ordenes);
            Boolean iniciada = OrdenIniciada(Ordenes, OrdenFabricacion);
            Boolean pausada = OrdenPausada(Ordenes, OrdenFabricacion);
            Boolean pospuesta = OrdenPospuesta(Ordenes, OrdenFabricacion);
            Boolean finalizada = OrdenFinalizada(Ordenes, OrdenFabricacion);
            switch (OpcionAccion)
            {
                /*Consulta si existe una orden iniciada o pausada*/
                case 1:
                    if (!ordenesIniciadas && (!finalizada || pausada || pospuesta))
                    {
                        resultado.Titulo = "Iniciar proceso";
                        resultado.Contenido = "¿Está seguro que desea iniciar el proceso de la orden N°" + OrdenFabricacion + " ?";
                        resultado.ExisteProceso = true;
                    }
                    else
                    {
                        resultado.Titulo = "Falló iniciar proceso";
                        resultado.Contenido = "No se puede iniciar proceso de la orden N°" + OrdenFabricacion + ". Puede que ya esté en ejecución, exista otra orden iniciada o esté finalizada.";
                        resultado.ExisteProceso = false;
                    }                        
                    break;
                /*Solo se puede pausar si la orden está iniciada*/
                case 2:
                    if(iniciada)
                    {
                        resultado.Titulo = "Pausar proceso";
                        resultado.Contenido = "¿Está seguro que desea pausar el proceso de la orden N°" + OrdenFabricacion + " ?";
                        resultado.ExisteProceso = true;
                    }
                    else
                    {
                        resultado.Titulo = "Falló pausar proceso";
                        resultado.Contenido = "No se puede pausar el proceso de la orden N°" + OrdenFabricacion + ". Esto se puede deber a que la orden ya se encuentre pausada, no se haya inicializado, esté pospuesta, esté finalizada o exista otra orden en ejecución";
                        resultado.ExisteProceso = false;
                    }
                    break;
                /*Solo se puede posponer si la orden esta iniciada o pospuesta*/
                case 3:
                    if(iniciada || pausada)
                    {
                        resultado.Titulo = "Posponer proceso";
                        resultado.Contenido = "¿Está seguro que desea posponer el proceso de la orden N°" + OrdenFabricacion + " ?";
                        resultado.ExisteProceso = true;
                    }
                    else
                    {
                        resultado.Titulo = "Falló posponer proceso";
                        resultado.Contenido = "No se puede posponer el proceso de la orden N°" + OrdenFabricacion + ". Esto se puede deber a que la orden ya se encuentre pospuesta, no se haya inicializado, esté finalizada o exista otra orden en ejecución";
                        resultado.ExisteProceso = false;
                    }
                    break;
                /*Solo se puede finalizar si la orden esta iniciada, pausada o pospuesta*/
                default:
                    if(iniciada || pausada || pospuesta)
                    {
                        resultado.Titulo = "Finalizar proceso";
                        resultado.Contenido = "¿Está seguro que desea iniciar el finalizar de la orden N°" + OrdenFabricacion + " ?";
                        resultado.ExisteProceso = true;
                    }
                    else
                    {
                        resultado.Titulo = "Falló finalizar proceso";
                        resultado.Contenido = "No se puede finalizar el proceso de la orden N°" + OrdenFabricacion + ". Esto se puede deber a que la orden se encuentre finalizar o no se haya inicializado";
                        resultado.ExisteProceso = false;
                    }
                    
                    break;
            }
            return Json(resultado);
        }

        [HttpPost]
        public JsonResult GetMonitoreoBotellas(int OrdenFabricacion)
        {
            //String fecha = "2020-05-13";
            String fecha = DateTime.Now.ToString("yyyy-MM-dd");
            List<Botella> botellas = ConsultaProceso.LeerBotellas(fecha, OrdenFabricacion);
            if(botellas!=null)
            {
                return Json(botellas);
            }
            /*Manda un objeto vacio para que se active zero records y muestre que no hay información en la tabla*/
            return Json(new Object());
        }

        [HttpPost]
        public JsonResult GetMonitoreoCajas(int OrdenFabricacion)
        {
            //String fecha = "2020-05-13";
            String fecha = DateTime.Now.ToString("yyyy-MM-dd");
            List<Caja> caja = ConsultaProceso.LeerCajas(fecha, OrdenFabricacion);
            if(caja != null)
            {
                return Json(caja);
            }
            /*Manda un objeto vacio para que se active zero records y muestre que no hay información en la tabla*/
            return Json(new Object());
            

        }

        [HttpPost]
        public JsonResult GetCantCajas(int OrdenFabricacion)
        {
            //String fecha = "2020-05-13";
            String fecha = DateTime.Now.ToString("yyyy-MM-dd");
            List<Caja> caja = ConsultaProceso.LeerCajas(fecha, OrdenFabricacion);
            List<Orden> ordenes = ConsultaProceso.LeerOrdenes(fecha);
            int cajasPlanificadas = 0;
            int cantCajas = 0;
            double porcentaje = 0;
            
            if (caja != null)
            {
                cantCajas = caja.Count();
                for (int i = 0; i<ordenes.Count(); i++)
                {
                    if(ordenes[i].OrdenFabricacion==OrdenFabricacion)
                    {
                        cajasPlanificadas = ordenes[i].CajasPlanificadas;
                        break;
                    }
                }

                porcentaje = (double)((cantCajas * 100.0) / cajasPlanificadas);

            }

            var datosCaja = new
            {
                CantCajas = cantCajas,
                Porcentaje = Math.Round(porcentaje,2)
            };

            return Json(datosCaja);
        }



        [HttpPost]
        public JsonResult GetCantBotellas(int OrdenFabricacion)
        {
            //String fecha = "2020-05-13";
            String fecha = DateTime.Now.ToString("yyyy-MM-dd");
            List<Botella> botellas = ConsultaProceso.LeerBotellas(fecha, OrdenFabricacion);
            List<Orden> ordenes = ConsultaProceso.LeerOrdenes(fecha);
            int botellasPlanificadas = 0;
            int cantBotellas = 0;
            double porcentaje = 0;

            if (botellas!=null)
            {
                cantBotellas = botellas.Count();
                for (int i = 0; i < ordenes.Count(); i++)
                {
                    if (ordenes[i].OrdenFabricacion == OrdenFabricacion)
                    {
                        botellasPlanificadas = ordenes[i].BotellasPlanificadas;
                        break;
                    }
                }

                porcentaje = (double)((cantBotellas * 100.0) / botellasPlanificadas);   
            }
            var datosBotella = new
            {
                CantBotellas = cantBotellas,
                Porcentaje = Math.Round(porcentaje,2)
            };
            return Json(datosBotella);
        }


        [HttpPost]
        public JsonResult GetVelocidad(int OrdenFabricacion)
        {
            //String fecha = "2020-05-13";
            String fecha = DateTime.Now.ToString("yyyy-MM-dd");
            String hora = DateTime.Now.AddMinutes(-1).ToString("HH:mm");
            VelocidadProceso velocidad = ConsultaProceso.LeerVelocidad(fecha, hora, OrdenFabricacion);
            return Json(velocidad);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}