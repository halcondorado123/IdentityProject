using Identidad.Models.ModelUsuario;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace Identidad.Models
{
    public class IdentidadDbContext : IdentityDbContext<AppUsuario>
    {
        public DbSet<ClaimAudit> ClaimAudits { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<DepartamentoME> Departamentos { get; set; }
        public DbSet<DomicilioME> Domicilios { get; set; }
        public DbSet<EstatusME> Estatus { get; set; }
        public DbSet<GrupoSanguineoME> GrupoSanguineos { get; set; }
        public DbSet<EstadoCivilME> EstadoCivil { get; set; }
        public DbSet<LugarNacimientoME> LugaresNacimientos { get; set; }    // Evaluar posible eliminación
        public DbSet<MunicipioME> Municipios { get; set; }
        public DbSet<PaisME> Paises { get; set; }
        public DbSet<PersonaME> Personas { get; set; }
        public DbSet<TipoDocumentoME> TiposDocumentos { get; set; }

        public IdentidadDbContext(DbContextOptions<IdentidadDbContext> options)
            : base(options)
        {
        }

        public DbSet<AppUsuario> AppUsuarios { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Usuario>().HasKey(u => u.Id);
            modelBuilder.Entity<PersonaME>().HasKey(p => p.Id);
            modelBuilder.Entity<EstatusME>().HasKey(e => e.EstatusId);
            modelBuilder.Entity<TipoDocumentoME>().HasKey(t => t.DocumentoId);
            modelBuilder.Entity<GrupoSanguineoME>().HasKey(g => g.GrupoSanguineoId);
            modelBuilder.Entity<EstadoCivilME>().HasKey(l => l.EstadoCivilId);

            modelBuilder.Entity<PaisME>().HasKey(p => p.PaisId);
            modelBuilder.Entity<DepartamentoME>().HasKey(p => p.DepartamentoId);
            modelBuilder.Entity<MunicipioME>().HasKey(m => m.MunicipioId);

            modelBuilder.Entity<DomicilioME>().HasKey(d => d.DomicilioId);
            modelBuilder.Entity<LugarNacimientoME>().HasKey(l => l.LugarNacimientoId);

            modelBuilder.Entity<ClaimAudit>()
                .ToTable("ClaimAudit")
                .HasKey(ca => ca.Id);

            // Configuración de la relación uno a uno
            modelBuilder.Entity<DomicilioME>()
                .HasOne(d => d.Persona)
                .WithOne(p => p.Domicilio)
                .HasForeignKey<DomicilioME>(d => d.Id); // Especifica la clave foránea

            modelBuilder.Entity<LugarNacimientoME>()
                .HasOne(d => d.Persona)
                .WithOne(p => p.LugarNacimiento)
                .HasForeignKey<LugarNacimientoME>(d => d.Id); // Especifica la clave foránea

            modelBuilder.Entity<PaisME>()
               .HasMany(p => p.Departamentos)
               .WithOne(d => d.Pais)
               .HasForeignKey(d => d.PaisId);

            modelBuilder.Entity<DepartamentoME>()
                .HasMany(d => d.Municipios)
                .WithOne(m => m.Departamento)
                .HasForeignKey(m => m.DepartamentoId);


            // Establecer Schema personalizado a mis elementos de Identity
            modelBuilder.Entity<IdentityUser>(entity =>
            {
                entity.ToTable("AspNetUsers", "Iden"); // Cambia "esquema" por el nombre de tu esquema
            });

            modelBuilder.Entity<IdentityRole>(entity =>
            {
                entity.ToTable("AspNetRoles", "Iden");
            });

            modelBuilder.Entity<IdentityUserClaim<string>>(entity =>
            {
                entity.ToTable("AspNetUserClaims", "Iden");
            });

            modelBuilder.Entity<IdentityUserRole<string>>(entity =>
            {
                entity.ToTable("AspNetUserRoles", "Iden");
            });

            modelBuilder.Entity<IdentityUserLogin<string>>(entity =>
            {
                entity.ToTable("AspNetUserLogins", "Iden");
            });

            modelBuilder.Entity<IdentityRoleClaim<string>>(entity =>
            {
                entity.ToTable("AspNetRoleClaims", "Iden");
            });

            modelBuilder.Entity<IdentityUserToken<string>>(entity =>
            {
                entity.ToTable("AspNetUserTokens", "Iden");
            });

            modelBuilder.Entity<IdentityRoleClaim<string>>(entity =>
            {
                entity.ToTable("__EFMigrationsHistory", "Iden");
            });

            modelBuilder.Entity<ClaimAudit>().ToTable("ClaimAudit", "Iden");


        }
    }
}
