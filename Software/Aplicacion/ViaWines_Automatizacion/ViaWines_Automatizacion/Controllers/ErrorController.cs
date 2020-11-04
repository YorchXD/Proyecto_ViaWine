using Microsoft.AspNetCore.Mvc;
using System;


namespace ViaWines_Automatizacion.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        [HttpGet]
        public ActionResult OperacionNoAutorizada(String operacion, String controlador, String msjeErrorExcepcion)
        {
            ViewBag.operacion = operacion;
            ViewBag.controlador = controlador;
            ViewBag.msjeErrorExcepcion = msjeErrorExcepcion;
            return View();
        }
    }
}