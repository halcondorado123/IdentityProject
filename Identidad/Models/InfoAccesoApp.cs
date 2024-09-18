using System.ComponentModel.DataAnnotations.Schema;

namespace Identidad.Models
{
    [Table("InfoAccesoApp", Schema = "Iden")]
    public class InfoAccesoApp
    {
        public string? NombreUsuario { get; set; }
        public string? FechaHora { get; set; }
    }
}
