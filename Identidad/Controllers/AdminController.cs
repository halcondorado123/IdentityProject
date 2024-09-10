using Identidad.Models;
using Identidad.Models.ModelUsuario;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Identidad.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View(userManager.Users);
        }
        private IdentidadDbContext dbContext;
        private UserManager<AppUsuario> userManager;
        private IPasswordHasher<AppUsuario> passwordHasher;
        private IPasswordValidator<AppUsuario> passwordValidator;
        private IUserValidator<AppUsuario> userValidator;

        public AdminController(IdentidadDbContext context, UserManager<AppUsuario> userManager, IPasswordHasher<AppUsuario> passwordHash, IPasswordValidator<AppUsuario> passwordValidator, IUserValidator<AppUsuario> userValidator)
        {
            this.userManager = userManager;
            this.passwordHasher = passwordHash;
            this.passwordValidator = passwordValidator;
            this.userValidator = userValidator;
            this.dbContext = context;
        }

        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                // Crear el nuevo usuario para el sistema de autenticación
                var appUsuario = new AppUsuario
                {
                    UserName = usuario.NombreUsuario,
                    Nombres = usuario.Nombres,
                    Apellidos = usuario.Apellidos,
                    Email = usuario.Email,
                    TipoDocumento = usuario.TipoDocumento,
                    NumeroDocumento = usuario.NumeroDocumento,
                    FechaNacimiento = usuario.FechaNacimiento,
                    Edad = usuario.Edad,
                    PaisNacimiento = usuario.PaisNacimiento,
                    DepartamentoNacimiento = usuario.DepartamentoNacimiento,
                    MunicipioNacimiento = usuario.MunicipioNacimiento,
                    DireccionDomicilio = usuario.DireccionDomicilio,
                    PaisDomicilio = usuario.PaisDomicilio,
                    DepartamentoDomicilio = usuario.DepartamentoDomicilio,
                    MunicipioDomicilio = usuario.MunicipioDomicilio,
                    EmailPersonal = usuario.EmailPersonal,
                    EmailInstitucional = usuario.EmailInstitucional,
                    TelefonoCelular = usuario.TelefonoCelular,
                    TelefonoFijo = usuario.TelefonoFijo,
                    ContratoEmpleado = usuario.ContratoEmpleado,
                    Salario = usuario.Salario,
                    CargoEmpleado = usuario.CargoEmpleado,
                };

                // Crear el usuario en la base de datos de identidad
                IdentityResult resultado = await userManager.CreateAsync(appUsuario, usuario.Password);

                if (resultado.Succeeded)
                {
                    // Agregar un claim al usuario si es necesario
                    var claimType = "Crear perfil"; // Cambia esto según el tipo de claim que necesitas
                    var claimValue = "Nuevo Usuario"; // Cambia esto según el valor del claim que necesitas

                    var claimResult = await userManager.AddClaimAsync(appUsuario, new Claim(claimType, claimValue));

                    if (claimResult.Succeeded)
                    {
                        // Redirigir a la acción Index si se agrega el claim correctamente
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        // Agregar errores de claim al modelo si el claim no se agrega
                        foreach (var error in claimResult.Errors)
                        {
                            ModelState.AddModelError("", error.Description);
                        }
                    }
                }
                else
                {
                    // Agregar errores de creación de usuario al modelo
                    foreach (IdentityError error in resultado.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }

            return View(usuario);
        }

        // Mediante Http Get

        public async Task<IActionResult> Update(string id)
        {
            AppUsuario usuario = await userManager.FindByIdAsync(id);
            if (usuario != null)
            {
                //ViewBag.Paises = ListUtils.GetPaises();
                //ViewBag.Departamentos = ListUtils.GetDepartamentos();
                //ViewBag.Municipios = ListUtils.GetMunicipios();
                //ViewBag.Contratos = ListUtils.GetContratos();
                return View(usuario);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }


        [HttpPost]
        public async Task<IActionResult> Update(Usuario usuario, string password)
        {
            if (!ModelState.IsValid)
            {
                return View("Edit", usuario);
            }

            var existingUser = await userManager.FindByIdAsync(usuario.Id.ToString());

            if (existingUser == null)
            {
                return NotFound();
            }

            // Actualizar los campos del usuario
            existingUser.Nombres = usuario.Nombres;
            existingUser.Apellidos = usuario.Apellidos;
            existingUser.Email = usuario.Email;
            existingUser.TipoDocumento = usuario.TipoDocumento;
            existingUser.NumeroDocumento = usuario.NumeroDocumento;
            existingUser.FechaNacimiento = usuario.FechaNacimiento;
            existingUser.Edad = usuario.Edad;
            existingUser.PaisNacimiento = usuario.PaisNacimiento;
            existingUser.DepartamentoNacimiento = usuario.DepartamentoNacimiento;
            existingUser.MunicipioNacimiento = usuario.MunicipioNacimiento;
            existingUser.DireccionDomicilio = usuario.DireccionDomicilio;
            existingUser.PaisDomicilio = usuario.PaisDomicilio;
            existingUser.DepartamentoDomicilio = usuario.DepartamentoDomicilio;
            existingUser.MunicipioDomicilio = usuario.MunicipioDomicilio;
            existingUser.EmailPersonal = usuario.EmailPersonal;
            existingUser.EmailInstitucional = usuario.EmailInstitucional;
            existingUser.TelefonoCelular = usuario.TelefonoCelular;
            existingUser.TelefonoFijo = usuario.TelefonoFijo;
            existingUser.ContratoEmpleado = usuario.ContratoEmpleado;
            existingUser.Salario = usuario.Salario;
            existingUser.CargoEmpleado = usuario.CargoEmpleado;

            // Manejo de la contraseña
            if (!string.IsNullOrEmpty(password))
            {
                var passwordResult = await passwordValidator.ValidateAsync(userManager, existingUser, password);

                if (passwordResult.Succeeded)
                {
                    existingUser.PasswordHash = passwordHasher.HashPassword(existingUser, password);
                }
                else
                {
                    foreach (var error in passwordResult.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }

                    return View("Edit", usuario);
                }
            }

            var updateResult = await userManager.UpdateAsync(existingUser);

            if (updateResult.Succeeded)
            {
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var error in updateResult.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                return View("Edit", usuario);
            }
        }


        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            AppUsuario Usuario = await userManager.FindByIdAsync(id);
            if (Usuario != null)
            {
                IdentityResult resultado = await userManager.DeleteAsync(Usuario);
                if (resultado.Succeeded)
                    return RedirectToAction("Index");
                else
                {
                    Errors(resultado);
                }
            }
            else
            {
                ModelState.AddModelError("", "Usuario no encontrado");
            }
            return View("Index", userManager.Users);
        }

        private void Errors(IdentityResult resultado)
        {
            foreach (IdentityError error in resultado.Errors)
                ModelState.AddModelError("", error.Description);
        }

    }
}
