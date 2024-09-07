using Identidad.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Identidad.Controllers
{
    public class RoleController : Controller
    {

        private RoleManager<IdentityRole> _roleManager;
        private UserManager<AppUsuario> _userManager;

        public RoleController(RoleManager<IdentityRole> roleManager, UserManager<AppUsuario> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            return View(_roleManager.Roles);
        }

        // Peticion HTTP GEt, para poder crear un rol
        public IActionResult Create()
        {
            return View();
        }

        // Permitira crear el usuario en base de datos.
        [HttpPost]
        [Authorize(Roles = "Administración")]
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


        // Este metodo ayuda a buscar metodos mediante peticion tipo GET; a miembros y no miembos
        public async Task<IActionResult> Update(string id)
        {
            IdentityRole rol = await _roleManager.FindByIdAsync(id);
            List<AppUsuario> miembros = new List<AppUsuario>();
            List<AppUsuario> Nomiembros = new List<AppUsuario>();

            foreach (AppUsuario usuario in _userManager.Users)
            {
                // IsInRole, determina si es verdadero si el usuario es miembro de rol en especifico, de lo contrario arrojará false
                var lista = await _userManager.IsInRoleAsync(usuario, rol.Name) ? miembros : Nomiembros;
                lista.Add(usuario);
            }

            return View(new RoleEditar
            {
                Role = rol,
                Members = miembros,
                NonMembers = Nomiembros
            });
        }

        // Metodo funcional para agregar o elimnar usuarios de role identity
        [HttpPost]
        public async Task<IActionResult> Update(RoleModificar modelo)
        {
            try
            {
                IdentityResult resultado;
                if (ModelState.IsValid)
                {
                    foreach (string usuarioId in modelo.AgregarIds ?? new string[] { })
                    {
                        AppUsuario usuario = await _userManager.FindByIdAsync(usuarioId);
                        if (usuario != null)
                        {
                            resultado = await _userManager.AddToRoleAsync(usuario, modelo.NombreRol);
                            if (!resultado.Succeeded)
                                ModelState.AddModelError("", "No se ha podido agregar el usuario al Rol");
                        }
                    }
                    foreach (string usuarioId in modelo.EliminarIds ?? new string[] { })
                    {
                        AppUsuario usuario = await _userManager.FindByIdAsync(usuarioId);
                        if (usuario != null)
                        {
                            resultado = await _userManager.RemoveFromRoleAsync(usuario, modelo.NombreRol);
                            if (!resultado.Succeeded)
                                ModelState.AddModelError("", "No se ha podido eliminar el usuario del rol");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }

            //try
            //{
            if (ModelState.IsValid)
            {
                return RedirectToAction(nameof(Index));
            }
            else
                return await Update(modelo.IdRol);
            //}

            //catch (Exception ex)
            //{
            //    ex.Message.ToString();
            //}
        }
    }
}
