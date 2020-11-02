using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ViaWines_Automatizacion.Models;
using Microsoft.AspNetCore.Http;
using System.Diagnostics;
using ViaWines_Automatizacion.DbAutomatizacionViaWines;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Identity.Client;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace ViaWines_Automatizacion.Controllers
{
    public class UsuarioController : Controller
    {

        [HttpPost]
        public async Task<IActionResult> Login(string email, string clave, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;

            // Normally Identity handles sign in, but you can do it directly
            var usuario = ConsultaUsuario.IniciarSesion(email);
            if (usuario!=null)
            {

                var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme, ClaimTypes.Name, ClaimTypes.Role);

                identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, email));
                identity.AddClaim(new Claim(ClaimTypes.Name, email));
                identity.AddClaim(new Claim(ClaimTypes.Role, "User"));

                var principal = new ClaimsPrincipal(identity);

                var authProperties = new AuthenticationProperties
                {
                    AllowRefresh = true,
                    //ExpiresUtc = DateTimeOffset.Now.AddDays(1),
                    IsPersistent = true,
                };

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(principal), authProperties);












                /*var claims = new List<Claim>
                {
                    new Claim("user", email),
                    new Claim("role", "Member")
                };

                await HttpContext.SignInAsync(new ClaimsPrincipal(new ClaimsIdentity(
                    claims, CookieAuthenticationDefaults.AuthenticationScheme, "user", "role")));*/

                if (Url.IsLocalUrl(returnUrl))
                {
                    return Redirect(returnUrl);
                }
                else
                {
                    return Redirect("/");
                }
            }

            return View();
        }

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