using Identidad.Models.ModelUsuario;
using Microsoft.AspNetCore.Identity;

namespace Identidad.Models
{
    public class AppUsuario : IdentityUser
    {
        public string? Nombres { get; set; }
        public string? Apellidos { get; set; }
        public string? TipoDocumento { get; set; }
        public string? NumeroDocumento { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public int Edad { get; set; }
        public string? PaisNacimiento { get; set; }
        public string? DepartamentoNacimiento { get; set; }
        public string? MunicipioNacimiento { get; set; }
        public string? DireccionDomicilio { get; set; }
        public string? PaisDomicilio { get; set; }
        public string? DepartamentoDomicilio { get; set; }
        public string? MunicipioDomicilio { get; set; }
        public string? EmailPersonal { get; set; }
        //public string? EmailInstitucional { get; set; }
        public string? TelefonoCelular { get; set; }
        public string? TelefonoFijo { get; set; }
        public string? ContratoEmpleado { get; set; }
        public string? Salario { get; set; }
        public string? CargoEmpleado { get; set; }
    }
}
