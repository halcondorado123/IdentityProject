using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Identidad.Models.ModelUsuario
{
    [Table("MunicipioME", Schema = "Iden")]
    public class MunicipioME
    {
        [Key]
        public int MunicipioId { get; set; }
        public string? Municipio { get; set; }

        // Clave foránea a DepartamentoME
        public int? DepartamentoId { get; set; }

        // Relación con Departamento
        public DepartamentoME? Departamento { get; set; }
    }
}
