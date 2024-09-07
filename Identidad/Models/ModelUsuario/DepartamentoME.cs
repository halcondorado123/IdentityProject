using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Identidad.Models.ModelUsuario
{
    public class DepartamentoME
    {
        [Key]
        public int DepartamentoId { get; set; }
        public string? Departamento { get; set; }
        public PaisME? Pais { get; set; }

    }
}
