using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Identidad.Models.ModelUsuario
{
    [Table("DepartamentoME", Schema = "Iden")]
    public class DepartamentoME
    {
        [Key]
        public int DepartamentoId { get; set; }
        public string? Departamento { get; set; }

        // Relación con Pais
        public PaisME? Pais { get; set; }

        // Clave foránea a PaisME
        public int? PaisId { get; set; }

        // Relación con Municipios
        public ICollection<MunicipioME>? Municipios { get; set; }

    }
}
