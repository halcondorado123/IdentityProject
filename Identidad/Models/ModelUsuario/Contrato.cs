using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Identidad.Models.ModelUsuario
{
    public class Contrato
    {
        [Key]
        public int ContratoEmpleadoId { get; set; }
        public string? TipoContrato { get; set; }
        //    public DateTime? FechaInicio { get; set; }
        //    public DateTime? FechaFin { get; set; }
        //    public bool ContratoActivo { get; set; }
        //    public string? Observaciones { get; set; }
    }
}