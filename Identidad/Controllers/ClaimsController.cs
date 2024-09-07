using Identidad.Helpers;
using Identidad.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;
using System.Security.Claims;

namespace Identidad.Controllers
{
    public class ClaimsController : Controller
    {
        private readonly UserManager<AppUsuario> _userManager;
        private readonly IAuthorizationService _authService;
        private readonly AuditLogger _auditLogger; // Inyecta AuditLogger

        // Constructor único que acepta todas las dependencias necesarias
        public ClaimsController(IdentidadDbContext context, UserManager<AppUsuario> userManager, IAuthorizationService authService, AuditLogger auditLogger)
        {
            _userManager = userManager;
            _authService = authService;
            _auditLogger = auditLogger;
        }

        //[Authorize]
        //[Authorize(Policy = "Segundo Email")]
        public ViewResult Index()
        {
            return View(User?.Claims);
        }

        public ViewResult Create()
        {
            return View();
        }


        // Obtener el usuario actual desde UserManager
        [HttpPost]
        public async Task<IActionResult> Create(string claimtype, string claimValue)
        {
            AppUsuario usuario = await _userManager.GetUserAsync(HttpContext.User);
            Claim reclamo = new Claim(claimtype, claimValue, ClaimValueTypes.String);

            // Crear nuevo reclamo para nuestro usuario
            IdentityResult resultado = await _userManager.AddClaimAsync(usuario, reclamo);
            if (resultado.Succeeded)
            {
                await _auditLogger.LogClaimChangeAsync(usuario.Id, claimtype, claimValue, "Add");
                return RedirectToAction("Index");
            }
            else
                ModelState.AddModelError("", "No se ha podido crear el reclamo");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string claimValues)
        {
            try
            {
                var usuario = await _userManager.GetUserAsync(HttpContext.User);

                if (usuario == null)
                {
                    ModelState.AddModelError("", "Usuario no encontrado.");
                    return View();
                }

                var claimValueArray = claimValues.Split(";");
                if (claimValueArray.Length < 3)
                {
                    ModelState.AddModelError("", "Formato de reclamo inválido.");
                    return View();
                }

                var claimType = claimValueArray[0];
                var claimValue = claimValueArray[1];
                var claimIssuer = claimValueArray[2];

                var reclamo = User.Claims
                    .FirstOrDefault(x => x.Type == claimType && x.Value == claimValue && x.Issuer == claimIssuer);

                if (reclamo == null)
                {
                    ModelState.AddModelError("", "Reclamo no encontrado.");
                    return View();
                }

                var resultado = await _userManager.RemoveClaimAsync(usuario, reclamo);

                if (resultado.Succeeded)
                {
                    await _auditLogger.LogClaimChangeAsync(usuario.Id, claimType, claimValue, "Remove");

                    // Actualizar claims en HttpContext
                    var updatedClaims = await _userManager.GetClaimsAsync(usuario);
                    var identity = new ClaimsIdentity(updatedClaims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(identity);
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "No se ha podido eliminar el reclamo.");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Ocurrió un error: {ex.Message}");
            }

            return View();
        }


        //[Authorize(Policy = "Segundo Email")]
        public ViewResult Proyecto()
        {
            return View("Index", User?.Claims);
        }

        [Authorize(Policy = "PermitirUsuarios")]
        public ViewResult SubirArchivos()
        {
            return View("Index", User?.Claims);
        }


        public async Task<IActionResult> AccesoPrivado(string titulo)
        {
            string[] UsuariosPermitidos = { "espana", "turbias" };
            AuthorizationResult resultado = await _authService.AuthorizeAsync(User, UsuariosPermitidos, "AccesoPrivado");

            if (resultado.Succeeded)
            {
                return View("Index", User?.Claims);     // Trae todos los Claims al(los) usuarios autorizados
            }

            else
            {
                return Content("Ha sucedido un error en el acceso a este recurso");
            }
        }
    }
}
