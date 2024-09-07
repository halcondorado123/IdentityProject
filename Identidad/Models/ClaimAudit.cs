using System.ComponentModel.DataAnnotations;

namespace Identidad.Models
{
    public class ClaimAudit
    { 
        public int Id { get; set; } // Identificador único del registro de auditoría
        public string UserId { get; set; } // Identificador del usuario
        public string ClaimType { get; set; } // Tipo del claim (por ejemplo, email, role, etc.)
        public string ClaimValue { get; set; } // Valor del claim
        public string Action { get; set; } // Acción realizada (por ejemplo, Add, Remove)
        public DateTime DateTime  { get; set; } // Fecha y hora del cambio
        public string ChangedBy { get; set; } // Usuario que realizó el cambio (opcional)
    }
}
