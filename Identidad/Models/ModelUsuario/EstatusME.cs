using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Identidad.Models.ModelUsuario
{
    [Table("EstatusME", Schema = "Iden")]
    public class EstatusME
    {
        [Key]
        public int? EstatusId { get; set; }
        [Required]
        public string? Estatus { get; set; }
    }
}
