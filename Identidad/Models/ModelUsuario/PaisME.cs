using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Identidad.Models.ModelUsuario
{
    public class PaisME
    {
        [Key]
        public int PaisId { get; set; }
        public string? Pais { get; set; }
    }
}
