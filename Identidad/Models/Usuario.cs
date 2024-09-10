using Identidad.Models.ModelUsuario;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Identidad.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }
        public string? NombreUsuario { get; set; }
        public string? Nombres { get; set; }
        public string? Apellidos { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? TipoDocumento { get; set; }
        public string? NumeroDocumento { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public int Edad { get; set; }

        // Claves foráneas para nacimiento
        //public int? PaisNacimientoId { get; set; }
        //[ForeignKey("PaisNacimientoId")]
        public string? PaisNacimiento { get; set; }

        //public int? DepartamentoNacimientoId { get; set; }
        //[ForeignKey("DepartamentoNacimientoId")]
        public string? DepartamentoNacimiento { get; set; }

        //public int? MunicipioNacimientoId { get; set; }
        //[ForeignKey("MunicipioNacimientoId")]
        public string? MunicipioNacimiento { get; set; }
        // Dirección de domicilio
        public string? DireccionDomicilio { get; set; }

        // Claves foráneas para domicilio
        //public int? PaisDomicilioId { get; set; }
        //[ForeignKey("PaisDomicilioId")]
        public string? PaisDomicilio { get; set; }

        //public int? DepartamentoDomicilioId { get; set; }
        //[ForeignKey("DepartamentoDomicilioId")]
        public string? DepartamentoDomicilio { get; set; }

        //public int? MunicipioDomicilioId { get; set; }
        //[ForeignKey("MunicipioDomicilioId")]
        public string? MunicipioDomicilio { get; set; }

        public string? EmailPersonal { get; set; }
        public string? EmailInstitucional { get; set; }
        public string? TelefonoCelular { get; set; }
        public string? TelefonoFijo { get; set; }
        //public int? ContratoEmpleadoId { get; set; }
        //[ForeignKey("ContratoEmpleadoId")]
        public string? ContratoEmpleado { get; set; }
        public string? Salario { get; set; }
        public string? CargoEmpleado { get; set; }
    }
}
