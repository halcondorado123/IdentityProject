using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Identidad.Models.ModelUsuario
{
    public class MunicipioME
    {
        [Key]
        public int MunicipioId { get; set; }
        public string? Municipio { get; set; }
        public DepartamentoME? Departamento { get; set; }
    }
}
