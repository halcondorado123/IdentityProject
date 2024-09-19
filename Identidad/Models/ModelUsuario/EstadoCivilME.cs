using System.ComponentModel.DataAnnotations.Schema;

namespace Identidad.Models.ModelUsuario
{
    [Table("EstadoCivilME", Schema = "Iden")]
    public class EstadoCivilME
    {
        public int? EstadoCivilId { get; set; }
        public string? EstadoCivil { get; set; }
    }
}
