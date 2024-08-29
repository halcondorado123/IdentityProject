using Identidad.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Identidad.Controllers
{
    public class HomeController : Controller
    {

        private UserManager<AppUsuario> _userManager;

        public HomeController(UserManager<AppUsuario> usrManager)
        {
            _userManager = usrManager;
        }

        // Solamente mostrara la vista si el usuario esta autenticado
        //[Authorize(Roles = "Administración")]
        [Authorize(Roles = "Recursos Humanos")]
        public async Task<IActionResult> Index()
        {
            AppUsuario usuario = await _userManager.GetUserAsync(HttpContext.User);

            string mensaje = "Hola " + usuario.UserName;

            return View((object)mensaje);
        }


    }
}
