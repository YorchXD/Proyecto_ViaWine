// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Microsoft.Identity.Web.UI.Areas.MicrosoftIdentity.Controllers
{
    /// <summary>
    /// Controller used in web apps to manage accounts.
    /// </summary>
    [NonController]
    [AllowAnonymous]
    [Area("MicrosoftIdentity")]
    [Route("[area]/[controller]/[action]")]
    public class AccountController : Controller
    {
        private readonly IOptions<MicrosoftIdentityOptions> _options;

        /// <summary>
        /// Constructor of <see cref="AccountController"/> from <see cref="MicrosoftIdentityOptions"/>
        /// This constructor is used by dependency injection.
        /// </summary>
        /// <param name="microsoftIdentityOptions">Configuration options.</param>
        public AccountController(IOptions<MicrosoftIdentityOptions> microsoftIdentityOptions)
        {
            _options = microsoftIdentityOptions;
        }

        /// <summary>
        /// Handles user sign in.
        /// </summary>
        /// <param name="scheme">Authentication scheme.</param>
        /// <returns>Challenge generating a redirect to Azure AD to sign in the user.</returns>
        [HttpGet("{scheme?}")]
        public IActionResult SignIn([FromRoute] string scheme)
        {
            scheme ??= OpenIdConnectDefaults.AuthenticationScheme;
            var redirectUrl = Url.Content("~/");

            /*var usuario = ConsultaUsuario.IniciarSesion(email);
            if (usuario == null)
            {
                ViewBag.Error = "Usuario o clave invalida";
                return View();
            }

            HttpContext.Session.SetComplexData("DatosUsuario", usuario);
            HttpContext.Session.SetString("NombreUsuario", usuario.Nombre);
            HttpContext.Session.SetString("Cargo", usuario.Cargo);
            HttpContext.Session.SetString("Rol", usuario.IdRol.ToString());
            return RedirectToAction("Resumen", "Resumen");*/

            return Challenge(
                new AuthenticationProperties { RedirectUri = redirectUrl },
                scheme);
        }

        /// <summary>
        /// Challenges the user.
        /// </summary>
        /// <param name="redirectUri">Redirect URI.</param>
        /// <param name="scope">Scopes to request.</param>
        /// <param name="loginHint">Login hint.</param>
        /// <param name="domainHint">Domain hint.</param>
        /// <param name="claims">Claims.</param>
        /// <param name="policy">AAD B2C policy.</param>
        /// <returns>Challenge generating a redirect to Azure AD to sign in the user.</returns>
        [HttpGet("{scheme?}")]
        public IActionResult Challenge(
            string redirectUri,
            string scope,
            string loginHint,
            string domainHint,
            string claims,
            string policy)
        {
            string scheme = OpenIdConnectDefaults.AuthenticationScheme;
            Dictionary<string, string?> properties = new Dictionary<string, string?>
            {
                { Constants.Scope, scope },
                { Constants.LoginHint, loginHint },
                { Constants.DomainHint, domainHint },
                { Constants.Claims, claims },
                //{ Constants.Policy, policy },
            };
            AuthenticationProperties authenticationProperties = new AuthenticationProperties(properties);
            authenticationProperties.RedirectUri = redirectUri;

            return Challenge(
                authenticationProperties,
                scheme);
        }

        /// <summary>
        /// Handles the user sign-out.
        /// </summary>
        /// <param name="scheme">Authentication scheme.</param>
        /// <returns>Sign out result.</returns>
        [HttpGet("{scheme?}")]
        public IActionResult SignOut([FromRoute] string scheme)
        {
            if (AppServicesAuthenticationInformation.IsAppServicesAadAuthenticationEnabled)
            {
                return LocalRedirect(AppServicesAuthenticationInformation.LogoutUrl);
            }
            else
            {
                scheme ??= OpenIdConnectDefaults.AuthenticationScheme;
                var callbackUrl = Url.Page("/Account/SignedOut", pageHandler: null, values: null, protocol: Request.Scheme);
                return SignOut(
                     new AuthenticationProperties
                     {
                         RedirectUri = callbackUrl,
                     },
                     CookieAuthenticationDefaults.AuthenticationScheme,
                     scheme);
            }
        }
    }
}