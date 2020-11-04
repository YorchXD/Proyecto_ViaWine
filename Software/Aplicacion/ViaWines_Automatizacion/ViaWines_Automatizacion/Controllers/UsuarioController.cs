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

        public IActionResult ClaveTemporal()
        {
            return View();
        }

        public IActionResult Usuarios()
        {
            return View();
        }

        public IActionResult MiPerfil()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(String email, String clave)
        {
            try
            {
                String claveAux = Encriptar.GetSHA256(clave);
                Usuario usuario = ConsultaUsuario.IniciarSesion(email, claveAux);
                if (usuario == null)
                {
                    ViewBag.Error = "Usuario o clave invalida";
                    return View();
                }

                HttpContext.Session.SetComplexData("DatosUsuario", usuario);
                HttpContext.Session.SetString("NombreUsuario", usuario.Nombre);
                HttpContext.Session.SetString("Cargo", usuario.Cargo);
                HttpContext.Session.SetString("Rol", usuario.IdRol.ToString());

                if (usuario.EstadoClave == "Temporal")
                {
                    return RedirectToAction("ClaveTemporal", "Usuario");
                }

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

        [HttpPost]
        public JsonResult LeerUsuarios()
        {
            List<Usuario> usuarios = ConsultaUsuario.Leer_Usuarios();
            Boolean validar = false;

            if (usuarios != null)
            {
                validar = true;
            }

            var datos = new
            {
                validar = validar,
                usuarios = usuarios

            };
            return Json(datos);
        }

        [HttpPost]
        public JsonResult LeerRoles()
        {
            List<Rol> roles = ConsultaUsuario.Leer_Roles();
            Boolean validar = false;

            if (roles != null)
            {
                validar = true;
            }

            var datos = new
            {
                validar = validar,
                roles = roles

            };
            return Json(datos);
        }

        [HttpPost]
        public JsonResult AgregarUsuario(String Email, String Nombre, String Cargo, int RefRol)
        {
            String Clave = Encriptar.GetSHA256("123456");
            int idUsuario = ConsultaUsuario.Agregar_Usuario(Email, Nombre, Cargo, RefRol, Clave);
            Boolean validar = false;

            if (idUsuario != -1)
            {
                validar = true;
            }

            var datos = new
            {
                validar = validar

            };
            return Json(datos);
        }

        [HttpPost]
        public JsonResult ResetearClave(int IdUsuario)
        {
            String Clave = Encriptar.GetSHA256("123456");
            int idUsuario = ConsultaUsuario.Resetear_Clave(IdUsuario, Clave);
            Boolean validar = false;

            if (idUsuario != -1)
            {
                validar = true;
            }

            var datos = new
            {
                validar = validar

            };
            return Json(datos);
        }

        [HttpPost]
        public JsonResult EliminarUsuario(int IdUsuario)
        {
            int idUsuario = ConsultaUsuario.Eliminar_Usuario(IdUsuario);
            Boolean validar = false;

            if (idUsuario != -1)
            {
                validar = true;
            }

            var datos = new
            {
                validar = validar

            };
            return Json(datos);
        }

        [HttpPost]
        public JsonResult EditarPerfilUsuarios(int IdUsuario, String Email, String Nombre, String Cargo, int RefRol)
        {
            int confirmacion = ConsultaUsuario.Editar_Perfil_Usuario(IdUsuario, Email, Nombre, Cargo, RefRol);
            Boolean validar = false;

            if (confirmacion != -1)
            {
                validar = true;
            }

            var datos = new
            {
                validar = validar

            };
            return Json(datos);
        }

        [HttpPost]
        public JsonResult EditarMiPerfil(int IdUsuario, String Nombre, String Cargo)
        {
            int confirmacion = ConsultaUsuario.Editar_Mi_Perfil(IdUsuario, Nombre, Cargo);
            Boolean validar = false;

            if (confirmacion != -1)
            {
                validar = true;
                Usuario usuarioAux = HttpContext.Session.GetComplexData<Usuario>("DatosUsuario");
                usuarioAux.Nombre = Nombre;
                usuarioAux.Cargo = Cargo;
                HttpContext.Session.SetComplexData("DatosUsuario", usuarioAux);
                HttpContext.Session.SetString("NombreUsuario", usuarioAux.Nombre);
                HttpContext.Session.SetString("Cargo", usuarioAux.Cargo);
            }

            var datos = new
            {
                validar = validar
            };
            return Json(datos);
        }

        [HttpPost]
        public JsonResult VerMiPerfil()
        {
            Usuario usuarioAux = HttpContext.Session.GetComplexData<Usuario>("DatosUsuario");
            var datos = new
            {
                usuario = usuarioAux,
            };
            return Json(datos);
        }

        [HttpPost]
        public JsonResult ActualizarClave(String ClaveTemporal, String NuevaClave, String NuevaClaveConfirmada)
        {
            Boolean validar = false;
            String mensaje = "";
            if (ClaveTemporal != "" && NuevaClave != "" && NuevaClaveConfirmada != "")
            {
                if (!ClaveTemporal.Contains(" ") && !NuevaClave.Contains(" ") && !NuevaClaveConfirmada.Contains(" "))
                {
                    if (NuevaClave == NuevaClaveConfirmada)
                    {
                        if (NuevaClave != ClaveTemporal)
                        {
                            String claveActualAux = Encriptar.GetSHA256(ClaveTemporal);
                            String nuevaClaveAux = Encriptar.GetSHA256(NuevaClave);
                            Usuario usuarioAux = HttpContext.Session.GetComplexData<Usuario>("DatosUsuario");

                            int comprobar = ConsultaUsuario.Actualizar_Clave(usuarioAux.Id, claveActualAux, nuevaClaveAux);

                            if (comprobar == 1)
                            {
                                validar = true;
                                mensaje = "Se ha registrado su clave correctamente.";
                            }
                            else
                            {
                                mensaje = "No se ha podido actualizar su clave. Esto se puede deber a que la clave actual ingresada no coincide con la registrada o exista problemas de conexion. Favor de intentarlo nuevamente.";
                            }

                        }
                        else
                        {
                            mensaje = "La nueva clave no debe ser igual que la temporal. Favor de corregirlas e intente nuevamente.";
                        }
                    }
                    else
                    {
                        mensaje = "Las claves no coiciden. Favor de corregirlas e intente nuevamente.";
                    }
                }
                else
                {
                    mensaje = "Las claves no deben tener espacios. Favor de corregirlas e intente nuevamente.";
                }
            }
            else
            {
                mensaje = "Verifique que no existan campos sin completar e intentelo nuevamente.";
            }

            var datos = new
            {
                validar = validar,
                mensaje = mensaje
            };
            return Json(datos);
        }
    }
}