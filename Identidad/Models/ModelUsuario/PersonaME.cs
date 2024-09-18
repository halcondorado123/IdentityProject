using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.NetworkInformation;

namespace Identidad.Models.ModelUsuario
{
    [Table("PersonaME", Schema = "Iden")]
    public class PersonaME
    {
        public int? Id { get; set; }

        public EstatusME? Estatus { get; set; } // Relación con el estatus

        public TipoDocumentoME? TipoDocumento { get; set; }

        [Required]
        public string? NumeroDocumento { get; set; }
        [Required]
        public string? LugarExpedición { get; set; }        // Temporalmente se ingresa el caracter manualmente
        [Required]
        public GrupoSanguineoME? RH { get; set; }

        [Required]
        public string? Nombres { get; set; }

        [Required]
        public string? Apellidos { get; set; }


        [DataType(DataType.Date)]
        public DateTime? FechaNacimiento { get; set; }

        [DataType(DataType.Date)]
        public DateTime? FechaExpedicion { get; set; }

        [DataType(DataType.Date)]
        public DateTime? FechaVencimiento { get; set; }

        public int Edad { get; set; }

        public LugarNacimientoME? LugarNacimiento { get; set; }

        public DomicilioME? Domicilio { get; set; }

        [EmailAddress]
        public string? EmailPersonal { get; set; }

        [Phone]
        public string? TelefonoCelular { get; set; }

        [Phone]
        public string? TelefonoFijo { get; set; }

        // Nuevas propiedades
        [DataType(DataType.Date)]
        public DateTime? FechaCreacion { get; set; } = DateTime.Now; // Se establece la fecha de creación automáticamente

        // Nuevas propiedades
        [DataType(DataType.Date)]
        public DateTime? FechaActualizacion { get; set; } = DateTime.Now; // Se establece la fecha de creación automáticamente

    }
}
