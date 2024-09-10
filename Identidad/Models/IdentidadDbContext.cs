using Identidad.Models.ModelUsuario;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Identidad.Models
{
    public class IdentidadDbContext : IdentityDbContext<AppUsuario>
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<ClaimAudit> ClaimAudits { get; set; }

        //public DbSet<PaisME> Paises { get; set; }
        //public DbSet<DepartamentoME> Departamentos { get; set; }
        //public DbSet<MunicipioME> Municipios { get; set; }
        //public DbSet<Contrato> Contratos { get; set; }

        public IdentidadDbContext(DbContextOptions<IdentidadDbContext> options)
            : base(options)
        {
        }

        public DbSet<AppUsuario> AppUsuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ClaimAudit>()
                .ToTable("ClaimAudit")
                .HasKey(ca => ca.Id);

        }
    }
}
