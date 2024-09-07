using Identidad.Models.ModelUsuario;
using Microsoft.AspNetCore.Identity;

namespace Identidad.Models
{
    public class AppUsuario : IdentityUser
    {
        public string? Username { get; set; }
        public string? Nombres { get; set; }
        public string? Apellidos { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? TipoDocumento { get; set; }
        public string? NumeroDocumento { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public int Edad { get; set; }
        public int? PaisNacimientoId { get; set; }
        public PaisME? PaisNacimiento { get; set; }
        public int? DepartamentoNacimientoId { get; set; }
        public DepartamentoME? DepartamentoNacimiento { get; set; }
        public int? MunicipioNacimientoId { get; set; }
        public MunicipioME? MunicipioNacimiento { get; set; }

        // Dirección de domicilio
        public string? DireccionDomicilio { get; set; }
        public int? PaisDomicilioId { get; set; }
        public PaisME? PaisDomicilio { get; set; }
        public int? DepartamentoDomicilioId { get; set; }
        public DepartamentoME? DepartamentoDomicilio { get; set; }
        public int? MunicipioDomicilioId { get; set; }
        public MunicipioME? MunicipioDomicilio { get; set; }
        
        public string? EmailPersonal { get; set; }
        public string? EmailInstitucional { get; set; }
        public string? TelefonoCelular { get; set; }
        public string? TelefonoFijo { get; set; }
        public int? ContratoEmpleadoId { get; set; }
        public Contrato? ContratoEmpleado { get; set; }
        public string? Salario { get; set; }
        public string? CargoEmpleado { get; set; }
    }
}
