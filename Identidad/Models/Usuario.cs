using Identidad.Models.ModelUsuario;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Identidad.Models
{
    [Table("Usuario", Schema = "Iden")]
    public class Usuario
    {
        [Key]
        public string? Id { get; set; }

        public string? NombreUsuario { get; set; }

        [EmailAddress]
        public string? EmailCorporativo { get; set; }

        [DataType(DataType.Password)]
        public string? Password { get; set; }

        // Nueva propiedad para la confirmación de la contraseña
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Las contraseñas no coinciden.")]
        public string? ConfirmarPassword { get; set; }

        // Nueva propiedad para el estatus
        public int Estatus { get; set; } = 1; // Inicializa el estatus en 1
    }
}
