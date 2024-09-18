using System.ComponentModel.DataAnnotations.Schema;

namespace Identidad.Models.ModelUsuario
{
    [Table("LugarNacimientoME", Schema = "Iden")]
    public class LugarNacimientoME
    {
        public int? LugarNacimientoId { get; set; }
        public PaisME? Pais { get; set; }
        public DepartamentoME? Departamento { get; set; }
        public MunicipioME? Municipio { get; set; }

        // Foreign Keys
        public PersonaME? Persona { get; set; }
        public int? Id {get; set;}
    }
}
