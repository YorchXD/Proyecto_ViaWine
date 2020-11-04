using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using ViaWines_Automatizacion.DbAutomatizacionViaWines;
using ViaWines_Automatizacion.Models;

namespace ViaWines_Automatizacion.Filtros
{
    public class PermisosUsuario : Attribute, IAuthorizationFilter
    {
        private int idOperacion;
        public Usuario usuario { get; set; }

        public PermisosUsuario(int idOperacion = 0)
        {
            this.idOperacion = idOperacion;
        }
        public void OnAuthorization(AuthorizationFilterContext filterContext)
        {
            String nombreOperacion = "";
            String nombreControlador = "";
            try
            {
                this.usuario = filterContext.HttpContext.Session.GetComplexData<Usuario>("DatosUsuario");
                int cantOperaciones = ConsultaUsuario.Leer_Rol_Operacion(usuario.IdRol.ToString(), idOperacion);

                if (cantOperaciones < 1)
                {
                    Operacion operacion = ConsultaUsuario.Leer_Operacion(idOperacion);
                    Controlador controlador = ConsultaUsuario.Leer_Controlador(operacion.IdControlador);
                    nombreOperacion = operacion.Nombre;
                    nombreControlador = controlador.Nombre;
                    filterContext.Result = new RedirectResult("~/Error/OperacionNoAutorizada?operacion=" + nombreOperacion + "&controlador=" + nombreControlador + "&msjeErrorExcepcion=");

                }
            }
            catch (Exception ex)
            {
                filterContext.Result = new RedirectResult("~/Error/OperacionNoAutorizada?operacion=" + nombreOperacion + "&modulo=" + nombreControlador + "&msjeErrorExcepcion=" + ex.Message);
            }
        }
    }
}
