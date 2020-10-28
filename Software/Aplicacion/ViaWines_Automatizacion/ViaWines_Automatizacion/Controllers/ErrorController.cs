using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


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