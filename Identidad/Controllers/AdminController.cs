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
                    Email = usuario.EmailCorporativo,

                    Nombres = usuario.Nombres,
                    Apellidos = usuario.Apellidos,
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
                    TelefonoCelular = usuario.TelefonoCelular,
                    TelefonoFijo = usuario.TelefonoFijo,
                    ContratoEmpleado = usuario.ContratoEmpleado,
                    Salario = usuario.Salario,
                    CargoEmpleado = usuario.CargoEmpleado
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
                return View(usuario);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        //[HttpPost]
        //public async Task<IActionResult> Update(string id, string email, string password, string Nombres, string Apellidos, string TipoDocumento, string NumeroDocumento,
        //    DateTime? FechaNacimiento, int Edad, string PaisNacimiento, string DepartamentoNacimiento, string MunicipioNacimiento, string DireccionDomicilio,
        //    string PaisDomicilio, string DepartaqmentoNacimiento, string MunicipioDomicilio, string EmailPersonal, string EmailInstitucional, string TelefonoCelular, string TelefonoFijo,
        //    string ContratoEmpleado, string Salario, string CargoEmpleado)
        //{
        //    AppUsuario usuario = await userManager.FindByIdAsync(id);

        //    if (usuario != null)
        //    {
        //        IdentityResult emailValido = null;
        //        if (!string.IsNullOrEmpty(email))
        //        {
        //            emailValido = await userValidator.ValidateAsync(userManager, usuario);
        //            if (emailValido.Succeeded)
        //                usuario.Email = email;
        //            else
        //            {
        //                Errors(emailValido);
        //            }
        //        }
        //        else
        //        {
        //            ModelState.AddModelError("", "El Email no puede estar vacio");
        //        }

        //        IdentityResult passValido = null;
        //        if (!string.IsNullOrEmpty(password))
        //        {
        //            passValido = await passwordValidator.ValidateAsync(userManager, usuario, password);
        //            if (passValido.Succeeded)
        //                usuario.PasswordHash = passwordHasher.HashPassword(usuario, password);
        //            else
        //            {
        //                Errors(passValido);
        //            }
        //        }

        //        usuario.Nombres = Nombres;
        //        usuario.Apellidos = Apellidos;
        //        usuario.TipoDocumento = TipoDocumento;
        //        usuario.NumeroDocumento = NumeroDocumento;
        //        usuario.FechaNacimiento = FechaNacimiento;
        //        usuario.Edad = Edad;
        //        usuario.PaisNacimiento = PaisNacimiento;
        //        usuario.DepartamentoNacimiento = DepartamentoNacimiento;
        //        usuario.MunicipioNacimiento = MunicipioNacimiento;
        //        usuario.DireccionDomicilio = DireccionDomicilio;
        //        usuario.PaisDomicilio = PaisDomicilio;
        //        usuario.DepartamentoDomicilio = DepartaqmentoNacimiento;
        //        usuario.MunicipioDomicilio = MunicipioDomicilio;
        //        usuario.EmailPersonal = EmailPersonal;
        //        usuario.EmailInstitucional = EmailInstitucional;
        //        usuario.TelefonoCelular = TelefonoCelular;
        //        usuario.TelefonoFijo = TelefonoFijo;
        //        usuario.ContratoEmpleado = ContratoEmpleado;
        //        usuario.Salario = Salario;
        //        usuario.CargoEmpleado = CargoEmpleado;


        //        IdentityResult resultado = await userManager.UpdateAsync(usuario);

        //        if (resultado.Succeeded)
        //            return RedirectToAction("Index");
        //        else
        //            ModelState.AddModelError("", "No se ha podido actualizar el registro");

        //    }
        //    return View(usuario);
        //}


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
