using Identidad.Models.ModelUsuario;
using Microsoft.AspNetCore.Identity;

namespace Identidad.Models
{
    public class AppUsuario : IdentityUser
    {
        public EstatusME? Estatus { get; set; }
        public TipoDocumentoME? TipoDocumento { get; set; } // Se debe tomar el tipo de dato asi o string??
        public string? NumeroDocumento { get; set; }
        public string? LugarExpedición { get; set; }        // Temporalmente se ingresa el caracter manualmente
        public GrupoSanguineoME? RH { get; set; }           // Se debe tomar el tipo de dato asi o string??
        public string? Nombres { get; set; }
        public string? Apellidos { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public DateTime? FechaExpedicion { get; set; }
        public DateTime? FechaVencimiento { get; set; }
        public int? Edad { get; set; }
        public LugarNacimientoME? LugarNacimiento { get; set; }
        public DomicilioME? Domicilio { get; set; }
        public string? EmailPersonal { get; set; }
        public string? TelefonoCelular { get; set; }
        public string? TelefonoFijo { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public DateTime? FechaActualizacion { get; set; }

    }
}
