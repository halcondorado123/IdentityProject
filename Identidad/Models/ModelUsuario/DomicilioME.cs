using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Identidad.Models.ModelUsuario
{
    [Table("DomicilioME", Schema = "Iden")]
    public class DomicilioME
    {
        [Key]
        public int? DomicilioId { get; set; }
        public string? Direccion { get; set; }
        public PaisME? Pais { get; set; }
        public DepartamentoME? Departamento { get; set; }
        public MunicipioME? Municipio { get; set; }

        // Foreign Keys
        public PersonaME? Persona { get; set; }
        public int? Id { get; set; }

    }
}
