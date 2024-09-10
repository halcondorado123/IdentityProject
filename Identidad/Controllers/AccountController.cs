using Identidad.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Identidad.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        private UserManager<AppUsuario> userManager;
        //Realizar la autenticación de los usuario
        private SignInManager<AppUsuario> signInManager;

        public AccountController(UserManager<AppUsuario> usrManager, SignInManager<AppUsuario> signinManager)
        {
            userManager = usrManager;
            signInManager = signinManager;
        }

        // Muestra la vista asi no esten autenticados - Para que puedan ser autenticado
        [AllowAnonymous]
        public IActionResult Login(string returnUrl)
        {
            Login login = new Login();
            login.ReturnUrl = returnUrl;
            return View(login);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(Login login)
        {
            if (!ModelState.IsValid)
            {
                return View(login);
            }

            try
            {
                // Buscar el usuario por email
                AppUsuario usuario = await userManager.FindByEmailAsync(login.Email);

                if (usuario != null)
                {
                    // Intentar iniciar sesión
                    await signInManager.SignOutAsync();
                    Microsoft.AspNetCore.Identity.SignInResult resultado = await signInManager.PasswordSignInAsync(usuario, login.Password, false, false);

                    if (resultado.Succeeded)
                    {
                        return Redirect(login.ReturnUrl ?? "/");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Credenciales incorrectas. Por favor, inténtelo de nuevo.");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "No se encontró un usuario con este correo electrónico.");
                }
            }
            catch (Exception ex)
            {
                // Log de la excepción (puedes usar un servicio de logging aquí)
                // Ejemplo: _logger.LogError(ex, "Error en el inicio de sesión");

                ModelState.AddModelError("", "Se ha producido un error inesperado: " + ex.Message);
            }

            return View(login);
        }
    
    // Cierre de sesión
    public async Task<IActionResult> Logout()
        {

            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        
        }

        public IActionResult AccessDenied()
        {
            return View();
        }

    }
}
