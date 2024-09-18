using System.ComponentModel.DataAnnotations.Schema;

namespace Identidad.Models.ModelUsuario
{
    [Table("TipoDocumentoME", Schema = "Iden")]
    public class TipoDocumentoME
    {
        public int? Id { get; set; }
        public string? TipoDocumento { get; set; }
    }
}
