using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViaWines_Automatizacion.Controllers;
using ViaWines_Automatizacion.Models;



namespace ViaWines_Automatizacion.Filtros
{
    public class VerificarSesion : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            try
            {
                base.OnActionExecuting(filterContext);
                Usuario usuario = (Usuario)filterContext.HttpContext.Session.GetComplexData<Usuario>("DatosUsuario");
                if (usuario == null)
                {
                    if (filterContext.Controller is UsuarioController == false)
                    {
                        filterContext.HttpContext.Response.Redirect("/Usuario/Login");
                    }
                }
                
            }
            catch (Exception)
            {
                filterContext.Result = new RedirectResult("~/Usuario/Login");
            }

        }
    }
}
