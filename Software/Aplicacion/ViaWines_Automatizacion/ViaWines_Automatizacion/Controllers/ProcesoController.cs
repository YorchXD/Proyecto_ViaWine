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
            return View();
        }

        [HttpPost]
        public JsonResult GetOrdenes(String Fecha, int Tipo)
        {
            Boolean validacion;
            List<Orden> ordenes = ConsultaProceso.LeerOrdenes(Fecha, Tipo);
            if (ordenes != null)
            {
                validacion = true;
            }
            else
            {
                validacion = false;
                ordenes = new List<Orden>();
            }

            var datos = new { 
                validacion = validacion,
                ordenes = ordenes
            };


            /*Manda un objeto vacio para que se active "zero records" y muestre que no hay información en la tabla*/
            return Json(datos);

        }


        [HttpPost]
        public JsonResult ObtenerFecha(int Opcion)
        {
            List<String> fechasOrden;
            switch (Opcion)
            {
                case 1:
                    fechasOrden = ConsultaProceso.LeerFechasOrdenesAbiertas();
                    break;
                default:
                    fechasOrden = ConsultaProceso.GetFechasOrdenesPlanificadas();
                    break;
            }
            if (fechasOrden != null)
            {
                return Json(fechasOrden);
            }
            return Json(new object());
        }

        /*[HttpGet]
        public JsonResult GetFechasOrdenesPlanificadas()
        {
            List<String> fechasOrden = ConsultaProceso.GetFechasOrdenesPlanificadas();
            if (fechasOrden != null)
            {
                return Json(fechasOrden);
            }
            return Json(new object());
        }

        [HttpGet]
        public JsonResult GetFechaOrdenesAbiertas()
        {
            List<String> fechasOrden = ConsultaProceso.LeerFechasOrdenesAbiertas();
            if (fechasOrden != null)
            {
                return Json(fechasOrden);
            }
            return Json(new object());
        }*/

        [HttpPost]
        public JsonResult ActualizarEstadoProceso(int OrdenFabricacion, int Estado, String Fecha)//ActualizarOrden orden)
        {
            ConsultaProceso.InsertarLogEstadoOrden(OrdenFabricacion, Estado);
            int actualizacion = ConsultaProceso.ActualizarEstadoOrden(OrdenFabricacion, Estado, Fecha);
            if(actualizacion==1)
            {
                return Json(true);
            }
            return Json(false);
        }
        /*
         * Verifica si existe una orden iniciada o pausada
         */
        public Boolean OrdenesIniciadasPausadas(List<Orden> Ordenes)
        {
            if (Ordenes.Where(orden => orden.Estado == 1 || orden.Estado == 2).Count() > 0)
            {
                return true;
            }

            return false;
        }

        /**
         * Verifica si la orden iniciada o pausada es diferente a la que se quiere reanudar
         */
        public Boolean OrdenesIniciadasPausadasDiferente(List<Orden> Ordenes, int OrdenFabricacion)
        {

            if (Ordenes.Where(orden => (orden.Estado == 1 || orden.Estado == 2) && orden.OrdenFabricacion != OrdenFabricacion).Count() > 0)
            {
                return true;
            }
            return false;

        }

        /*
         * Consulta si una orden en particular se encuentra iniciada
         */
        public Boolean OrdenIniciada(List<Orden> Ordenes, int OrdenFabricacion)
        {
            if (Ordenes.Where(orden => orden.OrdenFabricacion == OrdenFabricacion && orden.Estado == 1).Count() > 0)
            {
                return true;
            }
            return false;

        }

        /*
         * Consulta si una orden en particular se encuentra pausada
         */
        public Boolean OrdenPausada(List<Orden> Ordenes, int OrdenFabricacion)
        {
            if (Ordenes.Where(orden => orden.OrdenFabricacion == OrdenFabricacion && orden.Estado == 2).Count() > 0)
            {
                return true;
            }
            return false;

        }

        /*
         * Consulta si una orden en particular se encuentra pospuesta
         */
        public Boolean OrdenPospuesta(List<Orden> Ordenes, int OrdenFabricacion)
        {
            if (Ordenes.Where(orden => orden.OrdenFabricacion == OrdenFabricacion && orden.Estado == 3).Count() > 0)
            {
                return true;
            }
            return false;
        }

        /*
         * Consulta si una orden en particular se encuentra finalizada
         */
        public Boolean OrdenFinalizada(List<Orden> Ordenes, int OrdenFabricacion)
        {
            if (Ordenes.Where(orden => orden.OrdenFabricacion == OrdenFabricacion && orden.Estado == 4).Count() > 0)
            {
                return true;
            }
            return false;
        }

        [HttpGet]
        public JsonResult Exit_proces_ini(int OpcionAccion, int OrdenFabricacion)//ActualizarOrden orden)
        {
            var resultado = new VistaModalIniciarProceso();

            if(OrdenFabricacion == -1)
            {
                switch(OpcionAccion)
                {
                    case 1:
                        resultado.Titulo = "Falló iniciar proceso";
                        resultado.Contenido = "No se puede iniciar proceso porque no ha seleccionado una orden.";
                        resultado.ExisteProceso = false;
                        break;
                    case 2:
                        resultado.Titulo = "Falló pausar proceso";
                        resultado.Contenido = "No se puede pausar proceso porque no ha seleccionado una orden que se encuentre iniciada.";
                        resultado.ExisteProceso = false;
                        break;
                    case 3:
                        resultado.Titulo = "Falló posponer proceso";
                        resultado.Contenido = "No se puede posponer proceso porque no ha seleccionado una orden.";
                        resultado.ExisteProceso = false;
                        break;
                    default:
                        resultado.Titulo = "Falló finalizar proceso";
                        resultado.Contenido = "No se puede finalizar proceso porque no ha seleccionado una orden.";
                        resultado.ExisteProceso = false;
                        break;
                }
            }
            else
            {
                //String fecha = "2020-05-08";
                //String fecha = DateTime.Now.ToString("yyyy-MM-dd");
                List<Orden> Ordenes = ConsultaProceso.LeerOrdenesAbiertas();
                Boolean ordenesIniciadasPausadas = OrdenesIniciadasPausadas(Ordenes);
                Boolean ordenIniciadasPausadasDiferente = OrdenesIniciadasPausadasDiferente(Ordenes, OrdenFabricacion);
                Boolean iniciada = OrdenIniciada(Ordenes, OrdenFabricacion);
                Boolean pausada = OrdenPausada(Ordenes, OrdenFabricacion);
                Boolean pospuesta = OrdenPospuesta(Ordenes, OrdenFabricacion);
                Boolean finalizada = OrdenFinalizada(Ordenes, OrdenFabricacion);
                switch (OpcionAccion)
                {
                    /*
                     * Iniciar ordenes
                     */
                    case 1:
                        /*Se puede iniciar cualquier orden siempre no se encuentre una orden iniciada o pausada, o si la orden a iniciar no se encuentra finalizada*/
                        if (!ordenesIniciadasPausadas && !finalizada && !pospuesta)
                        {
                            resultado.Titulo = "Iniciar proceso";
                            resultado.Contenido = "¿Está seguro que desea iniciar el proceso de la orden N°" + OrdenFabricacion + " ?";
                            resultado.ExisteProceso = true;
                        }
                        /*Se puede reanudar una orden en particular si se encuentra pospuesta o pausada*/
                        else if((pausada || pospuesta) && !ordenIniciadasPausadasDiferente )
                        {
                            resultado.Titulo = "Reanudar proceso";
                            resultado.Contenido = "¿Está seguro que desea reaundar el proceso de la orden N°" + OrdenFabricacion + " ?";
                            resultado.ExisteProceso = true;
                        }
                        /*
                         * El inicio de una orden puede fallar porque existe otra orden en ejecucion (iniciada o pausada) o se encuentra finalizada
                         */
                        else
                        {
                            resultado.Titulo = "Falló iniciar proceso";
                            resultado.Contenido = "No se puede iniciar proceso de la orden N°" + OrdenFabricacion + ". Puede que la orden se encuentra en ejecución o finalizada, o puede que exista otra orden iniciada o pausada.";
                            resultado.ExisteProceso = false;
                        }
                        break;
                    /*Solo se puede pausar si la orden está iniciada*/
                    case 2:
                        if (iniciada)
                        {
                            resultado.Titulo = "Pausar proceso";
                            resultado.Contenido = "¿Está seguro que desea pausar el proceso de la orden N°" + OrdenFabricacion + " ?";
                            resultado.ExisteProceso = true;
                        }
                        else
                        {
                            resultado.Titulo = "Falló pausar proceso";
                            resultado.Contenido = "No se puede pausar el proceso de la orden N°" + OrdenFabricacion + ". Esto puede ocurrir porque la orden ya se encuentra pausada, no se haya inicializado, esté pospuesta, esté finalizada o exista otra orden en ejecución";
                            resultado.ExisteProceso = false;
                        }
                        break;
                    /*Solo se puede posponer si la orden esta iniciada o pospuesta*/
                    case 3:
                        if (iniciada || pausada)
                        {
                            resultado.Titulo = "Posponer proceso";
                            resultado.Contenido = "¿Está seguro que desea posponer el proceso de la orden N°" + OrdenFabricacion + " ?";
                            resultado.ExisteProceso = true;
                        }
                        else
                        {
                            resultado.Titulo = "Falló posponer proceso";
                            resultado.Contenido = "No se puede posponer el proceso de la orden N°" + OrdenFabricacion + ". Esto puede ocurrir porque la orden ya se encuentra pospuesta, no se haya inicializado, esté finalizada o exista otra orden en ejecución";
                            resultado.ExisteProceso = false;
                        }
                        break;
                    /*Solo se puede finalizar si la orden esta iniciada, pausada o pospuesta*/
                    default:
                        if (iniciada || pausada || pospuesta)
                        {
                            resultado.Titulo = "Finalizar proceso";
                            resultado.Contenido = "¿Está seguro que desea finalizar de la orden N°" + OrdenFabricacion + " ?";
                            resultado.ExisteProceso = true;
                        }
                        else
                        {
                            resultado.Titulo = "Falló finalizar proceso";
                            resultado.Contenido = "No se puede finalizar el proceso de la orden N°" + OrdenFabricacion + ". Esto puede ocurrir porque la orden ya se encuentra finalizada o no se haya inicializado";
                            resultado.ExisteProceso = false;
                        }

                        break;
                }
            }
            return Json(resultado);
        }

        [HttpPost]
        public JsonResult GetMonitoreoMateriales(int OrdenFabricacion, String Fecha)
        {
            List<Material> materiales = ConsultaProceso.LeerMaterial(OrdenFabricacion, Fecha);
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
            int cantTpoMaterial = ConsultaProceso.LeerVelocidadMaterial(fecha, hora, OrdenFabricacion, TipoMaterial);
            if (cantTpoMaterial == -1)
            {
                cantTpoMaterial = 0;
            }
            return Json(cantTpoMaterial);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public JsonResult LeerOrdenesAbiertas()
        {
            List<Orden> ordenes = ConsultaProceso.LeerOrdenesAbiertas();
            if (ordenes != null)
            {
                return Json(ordenes);
            }
            return Json(new object());
        }

        /*[HttpPost]
        public JsonResult GetMonitoreoBotellas(int OrdenFabricacion)
        {
            //String fecha = "2020-05-13";
            String fecha = DateTime.Now.ToString("yyyy-MM-dd");
            List<Botella> botellas = ConsultaProceso.LeerBotellas(fecha, OrdenFabricacion);
            if(botellas!=null)
            {
                return Json(botellas);
            }
            //Manda un objeto vacio para que se active zero records y muestre que no hay información en la tabla
            return Json(new Object());
        }*/

        /*[HttpPost]
        public JsonResult GetMonitoreoCajas(int OrdenFabricacion)
        {
            //String fecha = "2020-05-13";
            String fecha = DateTime.Now.ToString("yyyy-MM-dd");
            List<Caja> caja = ConsultaProceso.LeerCajas(fecha, OrdenFabricacion);
            if(caja != null)
            {
                return Json(caja);
            }
            //Manda un objeto vacio para que se active zero records y muestre que no hay información en la tabla
            return Json(new Object());
        }*/

        /*[HttpPost]
        public JsonResult GetCantCajas(int OrdenFabricacion, int CajasPlanificadas)
        {
            //String fecha = "2020-05-13";
            String fecha = DateTime.Now.ToString("yyyy-MM-dd");
            List<Caja> caja = ConsultaProceso.LeerCajas(fecha, OrdenFabricacion);
            //List<Orden> ordenes = ConsultaProceso.LeerOrdenes(fecha);
            //int cajasPlanificadas = 0;
            int cantCajas = 0;
            double porcentaje = 0;
            
            if (caja != null)
            {
                cantCajas = caja.Count();
                porcentaje = (double)((cantCajas * 100.0) / CajasPlanificadas);
            }

            var datosCaja = new
            {
                CantCajas = cantCajas,
                Porcentaje = Math.Round(porcentaje,2)
            };

            return Json(datosCaja);
        }*/



        /*[HttpPost]
        public JsonResult GetCantBotellas(int OrdenFabricacion, int BotellasPlanificadas)
        {
            //String fecha = "2020-05-13";
            String fecha = DateTime.Now.ToString("yyyy-MM-dd");
            List<Botella> botellas = ConsultaProceso.LeerBotellas(fecha, OrdenFabricacion);
            //List<Orden> ordenes = ConsultaProceso.LeerOrdenes(fecha);
            //int botellasPlanificadas = 0;
            int cantBotellas = 0;
            double porcentaje = 0;

            if (botellas!=null)
            {
                cantBotellas = botellas.Count();
                porcentaje = (double)((cantBotellas * 100.0) / BotellasPlanificadas);   
            }
            var datosBotella = new
            {
                CantBotellas = cantBotellas,
                Porcentaje = Math.Round(porcentaje,2)
            };
            return Json(datosBotella);
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
        }*/

        /*[HttpPost]
        public JsonResult GetVelocidadCajas(int OrdenFabricacion)
        {
            //String fecha = "2020-05-13";
            String fecha = DateTime.Now.ToString("yyyy-MM-dd");
            String hora = DateTime.Now.AddMinutes(-1).ToString("HH:mm");
            int cantCajas = ConsultaProceso.LeerVelocidadCajas(fecha, hora, OrdenFabricacion);
            if(cantCajas == -1)
            {
                cantCajas = 0;
            }
            return Json(cantCajas);
        }*/
    }
}