using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Identidad.Models.ModelUsuario
{
    [Table("PaisME", Schema = "Iden")]
    public class PaisME
    {
        [Key]
        public int PaisId { get; set; } = 1;
        public string? Pais { get; set; } = "Colombia";

        // Relación con Departamentos
        public ICollection<DepartamentoME>? Departamentos { get; set; }
    }
}
