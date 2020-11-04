using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using ViaWines_Automatizacion.DbAutomatizacionViaWines;
using ViaWines_Automatizacion.Filtros;
using ViaWines_Automatizacion.Models;

namespace ViaWines_Automatizacion.Controllers
{
    public class IncidenteController : Controller
    {
        [PermisosUsuario(idOperacion: 8)]
        public IActionResult Incidente()
        {
            return View();
        }

        [PermisosUsuario(idOperacion: 8)]
        public IActionResult DetalleIncidente()
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
        public JsonResult LeerAreas()
        {
            List<Area> areas = ConsultaIncidente.LeerAreas();
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

        [PermisosUsuario(idOperacion: 9)]
        [HttpPost]
        public JsonResult FinalizarIncidenciaPorId(int IdIncidente, DateTime FechaHoraTermino)
        {
            int validacion = ConsultaIncidente.FinalizarIncidentePorId(IdIncidente, FechaHoraTermino);
            return Json(validacion);

        }

        [PermisosUsuario(idOperacion: 9)]
        [HttpPost]
        public JsonResult ActualizarObservacionIncidente(int IdIncidente, int IdArea, String Observacion)
        {
            int validacion = ConsultaIncidente.ActualizarObservacionIncidente(IdIncidente, IdArea, Observacion);
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

        [PermisosUsuario(idOperacion: 7)]
        [HttpPost]
        public JsonResult RegistrarIncidencia(int IdIncidente, int IdArea, DateTime FechaHoraInicio, String Observacion)
        {
            int IdIncidenteRegistrado = ConsultaIncidente.RegistrarIncidencia(IdIncidente, IdArea, FechaHoraInicio, Observacion);
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