using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Identidad.Controllers
{
    public class RoleController : Controller
    {

        private RoleManager<IdentityRole> _roleManager;
        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }
        public IActionResult Index()
        {
            return View(_roleManager.Roles);
        }

        // Peticion HHTP GEt, para poder crear un rol
        public IActionResult Create()
        {
            return View();
        }

        // Permitira crear el usuario en base de datos.
        [HttpPost]
        public async Task<IActionResult> Create([Required] string nombre)
        {
            if (ModelState.IsValid)
            {
                IdentityResult resultado = await _roleManager.CreateAsync(new IdentityRole(nombre));

                if (resultado.Succeeded)
                    return RedirectToAction("Index");
                else
                    foreach (IdentityError error in resultado.Errors)
                        ModelState.AddModelError("", error.Description);
            }
            return View(nombre);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        { 
            IdentityRole role = await _roleManager.FindByIdAsync(id);
            if (role != null)
            { 
                IdentityResult resultado = await _roleManager.DeleteAsync(role);
                if (resultado.Succeeded)
                    return RedirectToAction("Index");
                else
                    foreach (IdentityError error in resultado.Errors)
                        ModelState.AddModelError("", error.Description);
            }

            return View("Index", _roleManager.Roles);
        
        }
    }
}
