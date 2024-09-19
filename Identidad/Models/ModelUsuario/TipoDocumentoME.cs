using System.ComponentModel.DataAnnotations.Schema;

namespace Identidad.Models.ModelUsuario
{
    [Table("TipoDocumentoME", Schema = "Iden")]
    public class TipoDocumentoME
    {
        public int? DocumentoId { get; set; }
        public string? TipoDocumento { get; set; }
    }
}
