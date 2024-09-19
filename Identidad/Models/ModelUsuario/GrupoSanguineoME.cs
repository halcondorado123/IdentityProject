using System.ComponentModel.DataAnnotations.Schema;

namespace Identidad.Models.ModelUsuario
{
    [Table("GrupoSanguineoME", Schema = "Iden")]
    public class GrupoSanguineoME
    {
        public int GrupoSanguineoId { get; set; }

        public string? GrupoSanguineo { get; set; }
    }
}
