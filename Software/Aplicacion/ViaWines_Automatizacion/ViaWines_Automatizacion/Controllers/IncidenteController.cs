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
    public class IncidenteController : Controller
    {
        public IActionResult Incidente()
        {
            return View();
        }

        public IActionResult DetalleIncidente(int Id, String Fecha)
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public JsonResult ObtenerFechaIncidentes()
        {
            List<String> fechasIncidente = ConsultaIncidente.LeerFechasIncidentes();
            if (fechasIncidente != null)
            {

                return Json(fechasIncidente);
            }
            return Json(new object());
        }

        [HttpPost]
        public JsonResult ObtenerOPIDia(String Fecha)
        {
            Boolean validacion = false;
            List<IncidenteOPI> opiDia = ConsultaIncidente.LeerOPIDia(Fecha);
            if (opiDia != null)
            {
                validacion = true;
            }
            var datos = new
            {
                validacion = validacion,
                opiDia = opiDia
            };
            return Json(datos);
        }

        [HttpPost]
        public JsonResult ObtenerRegistrosIncidentes(String Fecha, int Id)
        {
            Boolean validacion = false;
            Incidente incidencias = ConsultaIncidente.LeerIncidencia(Id);
            List<RegistroIncidente> registros = ConsultaIncidente.LeerRegistroIncidente(Fecha, Id);
            if (registros != null)
            {
                validacion = true;
            }
            var datos = new
            {
                validacion = validacion,
                incidente = incidencias,
                registros = registros
            };
            return Json(datos);
        }

        [HttpPost]
        public JsonResult LeerIncidencias(int IdIncidente)
        {
            Incidente incidencias = ConsultaIncidente.LeerIncidencia(IdIncidente);
            if (incidencias != null)
            {
                return Json(incidencias);
            }
            return Json(new object());
        }

        [HttpPost]
        public JsonResult FinalizarIncidenciaPorId(int IdIncidente, DateTime FechaHoraTermino)
        {
            int validacion = ConsultaIncidente.FinalizarIncidentePorId(IdIncidente, FechaHoraTermino);
            return Json(validacion);

        }

        [HttpPost]
        public JsonResult ActualizarObservacionIncidente(int IdIncidente, String Observacion)
        {
            int validacion = ConsultaIncidente.ActualizarObservacionIncidente(IdIncidente, Observacion);
            return Json(validacion);

        }

        [HttpPost]
        public JsonResult LeerOPI()
        {
            List<Incidente> incidencias = ConsultaIncidente.LeerIncidencias();
            if (incidencias != null)
            {
                return Json(incidencias);
            }
            return Json(new object());
        }

        [HttpPost]
        public JsonResult RegistrarIncidencia(int IdIncidente, DateTime FechaHoraInicio, String Observacion)
        {
            int IdIncidenteRegistrado = ConsultaIncidente.RegistrarIncidencia(IdIncidente, FechaHoraInicio, Observacion);
            var resultado = new VistaModalIncidente();


            if (IdIncidenteRegistrado != -1)
            {
                resultado.Titulo = "Registro exitoso";
                resultado.Contenido = "La incidencia se ha registrado exitosamente.";
                resultado.RegistroExitoso = true;
            }
            else
            {
                resultado.Titulo = "Falló ingresar la incidencia";
                resultado.Contenido = "No se ha podido ingresar la incidencia. Intentelo nuevamente.";
                resultado.RegistroExitoso = false;

            }
            resultado.IdIncidente = IdIncidenteRegistrado;

            return Json(resultado);
        }
    }
}