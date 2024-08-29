using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Identidad.Models
{
    public class IdentidadDbContext : IdentityDbContext<AppUsuario>
    {
        public IdentidadDbContext(DbContextOptions<IdentidadDbContext> options)
            : base(options)
        {
        }
    }
}
