using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;
using ViaWines_Automatizacion.DbAutomatizacionViaWines;
using ViaWines_Automatizacion.Filtros;
using ViaWines_Automatizacion.Models;

namespace ViaWines_Automatizacion.Controllers
{
    public class ProcesoController : Controller
    {
        [PermisosUsuario(idOperacion: 5)]
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

        [PermisosUsuario(idOperacion: 6)]
        [HttpPost]
        public JsonResult ActualizarEstadoProceso(int Id, int Estado, String Fecha)//ActualizarOrden orden)
        {
            //ConsultaProceso.InsertarLogEstadoOrden(Id, Estado);

            int actualizacion = ConsultaProceso.ActualizarEstadoOrden(Id, Estado, Fecha);
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
        public Boolean OrdenesIniciadasPausadasDiferente(List<Orden> Ordenes, int IdOrden)
        {

            if (Ordenes.Where(orden => (orden.Estado == 1 || orden.Estado == 2) && orden.Id != IdOrden).Count() > 0)
            {
                return true;
            }
            return false;

        }

        /*
         * Consulta si una orden en particular se encuentra iniciada
         */
        public Boolean OrdenIniciada(List<Orden> Ordenes, int IdOrden)
        {
            if (Ordenes.Where(orden => orden.Id == IdOrden && orden.Estado == 1).Count() > 0)
            {
                return true;
            }
            return false;

        }

        /*
         * Consulta si una orden en particular se encuentra pausada
         */
        public Boolean OrdenPausada(List<Orden> Ordenes, int IdOrden)
        {
            if (Ordenes.Where(orden => orden.Id == IdOrden && orden.Estado == 2).Count() > 0)
            {
                return true;
            }
            return false;

        }

        /*
         * Consulta si una orden en particular se encuentra pospuesta
         */
        public Boolean OrdenPospuesta(List<Orden> Ordenes, int IdOrden)
        {
            if (Ordenes.Where(orden => orden.Id == IdOrden && orden.Estado == 3).Count() > 0)
            {
                return true;
            }
            return false;
        }

        /*
         * Consulta si una orden en particular se encuentra finalizada
         */
        public Boolean OrdenFinalizada(List<Orden> Ordenes, int IdOrden)
        {
            if (Ordenes.Where(orden => orden.Id == IdOrden && orden.Estado == 4).Count() > 0)
            {
                return true;
            }
            return false;
        }

        [HttpGet]
        public JsonResult Exit_proces_ini(int OpcionAccion, int IdOrden)//ActualizarOrden orden)
        {
            var resultado = new VistaModalIniciarProceso();

            if(IdOrden == -1)
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
                List<Orden> Ordenes = ConsultaProceso.LeerOrdenesAbiertas();
                Orden orden = Ordenes.Find(ordenAux => ordenAux.Id == IdOrden);
                Boolean ordenesIniciadasPausadas = OrdenesIniciadasPausadas(Ordenes);
                Boolean ordenIniciadasPausadasDiferente = OrdenesIniciadasPausadasDiferente(Ordenes, IdOrden);
                Boolean iniciada = OrdenIniciada(Ordenes, IdOrden);
                Boolean pausada = OrdenPausada(Ordenes, IdOrden);
                Boolean pospuesta = OrdenPospuesta(Ordenes, IdOrden);
                Boolean finalizada = OrdenFinalizada(Ordenes, IdOrden);
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
                            resultado.Contenido = "¿Está seguro que desea iniciar el proceso de la orden N°" + orden.OrdenFabricacion + " ?";
                            resultado.ExisteProceso = true;
                        }
                        /*Se puede reanudar una orden en particular si se encuentra pospuesta o pausada*/
                        else if((pausada || pospuesta) && !ordenIniciadasPausadasDiferente )
                        {
                            resultado.Titulo = "Reanudar proceso";
                            resultado.Contenido = "¿Está seguro que desea reaundar el proceso de la orden N°" + orden.OrdenFabricacion + " ?";
                            resultado.ExisteProceso = true;
                        }
                        /*
                         * El inicio de una orden puede fallar porque existe otra orden en ejecucion (iniciada o pausada) o se encuentra finalizada
                         */
                        else
                        {
                            resultado.Titulo = "Falló iniciar proceso";
                            resultado.Contenido = "No se puede iniciar proceso de la orden N°" + orden.OrdenFabricacion + ". Puede que la orden se encuentra en ejecución o finalizada, o puede que exista otra orden iniciada o pausada.";
                            resultado.ExisteProceso = false;
                        }
                        break;
                    /*Solo se puede pausar si la orden está iniciada*/
                    case 2:
                        if (iniciada)
                        {
                            resultado.Titulo = "Pausar proceso";
                            resultado.Contenido = "¿Está seguro que desea pausar el proceso de la orden N°" + orden.OrdenFabricacion + " ?";
                            resultado.ExisteProceso = true;
                        }
                        else
                        {
                            resultado.Titulo = "Falló pausar proceso";
                            resultado.Contenido = "No se puede pausar el proceso de la orden N°" + orden.OrdenFabricacion + ". Esto puede ocurrir porque la orden ya se encuentra pausada, no se haya inicializado, esté pospuesta, esté finalizada o exista otra orden en ejecución";
                            resultado.ExisteProceso = false;
                        }
                        break;
                    /*Solo se puede posponer si la orden esta iniciada o pospuesta*/
                    case 3:
                        if (iniciada || pausada)
                        {
                            resultado.Titulo = "Posponer proceso";
                            resultado.Contenido = "¿Está seguro que desea posponer el proceso de la orden N°" + orden.OrdenFabricacion + " ?";
                            resultado.ExisteProceso = true;
                        }
                        else
                        {
                            resultado.Titulo = "Falló posponer proceso";
                            resultado.Contenido = "No se puede posponer el proceso de la orden N°" + orden.OrdenFabricacion + ". Esto puede ocurrir porque la orden ya se encuentra pospuesta, no se haya inicializado, esté finalizada o exista otra orden en ejecución";
                            resultado.ExisteProceso = false;
                        }
                        break;
                    /*Solo se puede finalizar si la orden esta iniciada, pausada o pospuesta*/
                    default:
                        if (iniciada || pausada || pospuesta)
                        {
                            resultado.Titulo = "Finalizar proceso";
                            resultado.Contenido = "¿Está seguro que desea finalizar de la orden N°" + orden.OrdenFabricacion + " ?";
                            resultado.ExisteProceso = true;
                        }
                        else
                        {
                            resultado.Titulo = "Falló finalizar proceso";
                            resultado.Contenido = "No se puede finalizar el proceso de la orden N°" + orden.OrdenFabricacion + ". Esto puede ocurrir porque la orden ya se encuentra finalizada o no se haya inicializado";
                            resultado.ExisteProceso = false;
                        }

                        break;
                }
            }
            return Json(resultado);
        }

        [HttpPost]
        public JsonResult GetMonitoreoMateriales(int IdOrden)
        {
            List<Material> materiales = ConsultaProceso.LeerMaterial(IdOrden);
            if (materiales != null)
            {
                return Json(materiales);
            }
            /*Manda un objeto vacio para que se active zero records y muestre que no hay información en la tabla*/
            return Json(new Object());
        }

        [HttpPost]
        public JsonResult GetVelocidadPorMin(int IdOrden, string TipoMaterial)
        {
            //String fecha = "2020-05-13";
            String fecha = DateTime.Now.ToString("yyyy-MM-dd");
            String hora = DateTime.Now.AddMinutes(-1).ToString("HH:mm");
            int cantTpoMaterial = ConsultaProceso.LeerVelocidadMaterial(fecha, hora, IdOrden, TipoMaterial);
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

        [HttpPost]
        public JsonResult LeerIncidencias()
        {
            List<Incidente> incidencias = ConsultaProceso.LeerIncidencias();
            if (incidencias != null)
            {
                return Json(incidencias);
            }
            return Json(new object());
        }

        [HttpPost]
        public JsonResult LeerAreas()
        {
            List<Area> areas = ConsultaProceso.LeerAreas();
            Boolean validacion = false;
            if (areas != null)
            {
                validacion = true;
            }

            var datos = new
            {
                validacion = validacion,
                areas = areas
            };
            return Json(datos);
        }

        [PermisosUsuario(idOperacion: 4)]
        [HttpPost]
        public JsonResult RegistrarIncidencia(int IdOrden, int IdIncidente, int IdArea, String EstadoOrden, DateTime FechaHoraInicio, String Observacion, double CantCajas, double CantCajasPlan /*double Progreso*/)
        {
            double Progreso = (CantCajas / CantCajasPlan) * 100;
            Progreso = Math.Round(Progreso, 2);
            int IdIncidenteRegistrado = ConsultaProceso.RegistrarIncidencia(IdOrden, IdIncidente, IdArea, EstadoOrden, FechaHoraInicio, Observacion, Progreso);
            var resultado = new VistaModalIncidente();

            
            if(IdIncidenteRegistrado!=-1)
            {
                resultado.Titulo = "Registro exitoso";
                resultado.Contenido = "La incidencia se ha registrado exitosamente.";
                resultado.RegistroExitoso = true;
            }
            else
            {
                resultado.Titulo = "Falló ingresar la incidencia";
                resultado.Contenido = "No se ha podido ingresar la orden. Intentelo nuevamente.";
                resultado.RegistroExitoso = false;
                
            }
            resultado.IdIncidente = IdIncidenteRegistrado;

            return Json(resultado);
        }

        [PermisosUsuario(idOperacion: 6)]
        [HttpPost]
        public JsonResult FinalizarIncidencia(int IdOrden, DateTime FechaHoraTermino)
        {
            int validacion = ConsultaProceso.FinalizarIncidencia(IdOrden, FechaHoraTermino);
            return Json(validacion);
        }

    }
}