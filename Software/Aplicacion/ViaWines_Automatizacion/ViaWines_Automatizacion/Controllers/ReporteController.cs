using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ViaWines_Automatizacion.Controllers
{
    public class ReporteController : Controller
    {
        public IActionResult Reporte()
        {
            return View();
        }
    }
}
