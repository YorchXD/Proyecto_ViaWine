using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ViaWines_Automatizacion.Models;
using Microsoft.AspNetCore.Http;
using System.Diagnostics;
using ViaWines_Automatizacion.DbAutomatizacionViaWines;

namespace ViaWines_Automatizacion.Controllers
{
    public class UsuarioController : Controller
    {

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email)
        {
            try
            {
                var usuario = ConsultaUsuario.IniciarSesion(email);
                if(usuario == null)
                {
                    ViewBag.Error = "Usuario o clave invalida";
                    return View();
                }

                HttpContext.Session.SetComplexData("DatosUsuario", usuario);
                HttpContext.Session.SetString("NombreUsuario", usuario.Nombre);
                HttpContext.Session.SetString("Cargo", usuario.Cargo);
                HttpContext.Session.SetString("Rol", usuario.IdRol.ToString());
                return RedirectToAction("Resumen", "Resumen");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return View();
        }

        public IActionResult Logout()
        {
            try
            {
                HttpContext.Session.SetComplexData("DatosUsuario", null);
                HttpContext.Session.SetString("NombreUsuario", "");
                HttpContext.Session.SetString("Cargo", "");
                HttpContext.Session.SetString("Rol", "-1");
                return RedirectToAction("Login", "Usuario");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return View();
        }

    }
}