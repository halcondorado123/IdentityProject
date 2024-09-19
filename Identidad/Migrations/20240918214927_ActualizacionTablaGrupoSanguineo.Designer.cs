﻿// <auto-generated />
using System;
using Identidad.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Identidad.Migrations
{
    [DbContext(typeof(IdentidadDbContext))]
    [Migration("20240918214927_ActualizacionTablaGrupoSanguineo")]
    partial class ActualizacionTablaGrupoSanguineo
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.33")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Identidad.Models.AppUsuario", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("Apellidos")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("DomicilioId")
                        .HasColumnType("int");

                    b.Property<int?>("Edad")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("EmailPersonal")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("EstatusId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("FechaActualizacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("FechaExpedicion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("FechaNacimiento")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("FechaVencimiento")
                        .HasColumnType("datetime2");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("LugarExpedición")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("LugarNacimientoId")
                        .HasColumnType("int");

                    b.Property<string>("Nombres")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NumeroDocumento")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<int?>("RHGrupoSanguineoId")
                        .HasColumnType("int");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TelefonoCelular")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TelefonoFijo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TipoDocumentoId")
                        .HasColumnType("int");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("DomicilioId");

                    b.HasIndex("EstatusId");

                    b.HasIndex("LugarNacimientoId");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.HasIndex("RHGrupoSanguineoId");

                    b.HasIndex("TipoDocumentoId");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Identidad.Models.ClaimAudit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Action")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ChangedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ClaimAudit", "Iden");
                });

            modelBuilder.Entity("Identidad.Models.ModelUsuario.DepartamentoME", b =>
                {
                    b.Property<int>("DepartamentoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DepartamentoId"), 1L, 1);

                    b.Property<string>("Departamento")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PaisId")
                        .HasColumnType("int");

                    b.HasKey("DepartamentoId");

                    b.HasIndex("PaisId");

                    b.ToTable("DepartamentoME", "Iden");
                });

            modelBuilder.Entity("Identidad.Models.ModelUsuario.DomicilioME", b =>
                {
                    b.Property<int?>("DomicilioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("DomicilioId"), 1L, 1);

                    b.Property<int?>("DepartamentoId")
                        .HasColumnType("int");

                    b.Property<string>("Direccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Id")
                        .HasColumnType("int");

                    b.Property<int?>("MunicipioId")
                        .HasColumnType("int");

                    b.Property<int?>("PaisId")
                        .HasColumnType("int");

                    b.HasKey("DomicilioId");

                    b.HasIndex("DepartamentoId");

                    b.HasIndex("Id")
                        .IsUnique()
                        .HasFilter("[Id] IS NOT NULL");

                    b.HasIndex("MunicipioId");

                    b.HasIndex("PaisId");

                    b.ToTable("DomicilioME", "Iden");
                });

            modelBuilder.Entity("Identidad.Models.ModelUsuario.EstatusME", b =>
                {
                    b.Property<int?>("EstatusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("EstatusId"), 1L, 1);

                    b.Property<string>("Estatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EstatusId");

                    b.ToTable("EstatusME", "Iden");
                });

            modelBuilder.Entity("Identidad.Models.ModelUsuario.GrupoSanguineoME", b =>
                {
                    b.Property<int>("GrupoSanguineoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GrupoSanguineoId"), 1L, 1);

                    b.Property<string>("GrupoSanguineo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GrupoSanguineoId");

                    b.ToTable("GrupoSanguineoME", "Iden");
                });

            modelBuilder.Entity("Identidad.Models.ModelUsuario.LugarNacimientoME", b =>
                {
                    b.Property<int?>("LugarNacimientoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("LugarNacimientoId"), 1L, 1);

                    b.Property<int?>("DepartamentoId")
                        .HasColumnType("int");

                    b.Property<int?>("Id")
                        .HasColumnType("int");

                    b.Property<int?>("MunicipioId")
                        .HasColumnType("int");

                    b.Property<int?>("PaisId")
                        .HasColumnType("int");

                    b.HasKey("LugarNacimientoId");

                    b.HasIndex("DepartamentoId");

                    b.HasIndex("Id")
                        .IsUnique()
                        .HasFilter("[Id] IS NOT NULL");

                    b.HasIndex("MunicipioId");

                    b.HasIndex("PaisId");

                    b.ToTable("LugarNacimientoME", "Iden");
                });

            modelBuilder.Entity("Identidad.Models.ModelUsuario.MunicipioME", b =>
                {
                    b.Property<int>("MunicipioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MunicipioId"), 1L, 1);

                    b.Property<int?>("DepartamentoId")
                        .HasColumnType("int");

                    b.Property<string>("Municipio")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MunicipioId");

                    b.HasIndex("DepartamentoId");

                    b.ToTable("MunicipioME", "Iden");
                });

            modelBuilder.Entity("Identidad.Models.ModelUsuario.PaisME", b =>
                {
                    b.Property<int>("PaisId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PaisId"), 1L, 1);

                    b.Property<string>("Pais")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PaisId");

                    b.ToTable("PaisME", "Iden");
                });

            modelBuilder.Entity("Identidad.Models.ModelUsuario.PersonaME", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"), 1L, 1);

                    b.Property<string>("Apellidos")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Edad")
                        .HasColumnType("int");

                    b.Property<string>("EmailPersonal")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("EstatusId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("FechaActualizacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("FechaExpedicion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("FechaNacimiento")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("FechaVencimiento")
                        .HasColumnType("datetime2");

                    b.Property<string>("LugarExpedición")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombres")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumeroDocumento")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RHGrupoSanguineoId")
                        .HasColumnType("int");

                    b.Property<string>("TelefonoCelular")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TelefonoFijo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TipoDocumentoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EstatusId");

                    b.HasIndex("RHGrupoSanguineoId");

                    b.HasIndex("TipoDocumentoId");

                    b.ToTable("PersonaME", "Iden");
                });

            modelBuilder.Entity("Identidad.Models.ModelUsuario.TipoDocumentoME", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"), 1L, 1);

                    b.Property<string>("TipoDocumento")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TipoDocumentoME", "Iden");
                });

            modelBuilder.Entity("Identidad.Models.Usuario", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConfirmarPassword")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmailCorporativo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Estatus")
                        .HasColumnType("int");

                    b.Property<string>("NombreUsuario")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Usuario", "Iden");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", "Iden");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("__EFMigrationsHistory", "Iden");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AspNetUsers", "Iden");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", "Iden");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", "Iden");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", "Iden");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", "Iden");
                });

            modelBuilder.Entity("Identidad.Models.AppUsuario", b =>
                {
                    b.HasOne("Identidad.Models.ModelUsuario.DomicilioME", "Domicilio")
                        .WithMany()
                        .HasForeignKey("DomicilioId");

                    b.HasOne("Identidad.Models.ModelUsuario.EstatusME", "Estatus")
                        .WithMany()
                        .HasForeignKey("EstatusId");

                    b.HasOne("Identidad.Models.ModelUsuario.LugarNacimientoME", "LugarNacimiento")
                        .WithMany()
                        .HasForeignKey("LugarNacimientoId");

                    b.HasOne("Identidad.Models.ModelUsuario.GrupoSanguineoME", "RH")
                        .WithMany()
                        .HasForeignKey("RHGrupoSanguineoId");

                    b.HasOne("Identidad.Models.ModelUsuario.TipoDocumentoME", "TipoDocumento")
                        .WithMany()
                        .HasForeignKey("TipoDocumentoId");

                    b.Navigation("Domicilio");

                    b.Navigation("Estatus");

                    b.Navigation("LugarNacimiento");

                    b.Navigation("RH");

                    b.Navigation("TipoDocumento");
                });

            modelBuilder.Entity("Identidad.Models.ModelUsuario.DepartamentoME", b =>
                {
                    b.HasOne("Identidad.Models.ModelUsuario.PaisME", "Pais")
                        .WithMany("Departamentos")
                        .HasForeignKey("PaisId");

                    b.Navigation("Pais");
                });

            modelBuilder.Entity("Identidad.Models.ModelUsuario.DomicilioME", b =>
                {
                    b.HasOne("Identidad.Models.ModelUsuario.DepartamentoME", "Departamento")
                        .WithMany()
                        .HasForeignKey("DepartamentoId");

                    b.HasOne("Identidad.Models.ModelUsuario.PersonaME", "Persona")
                        .WithOne("Domicilio")
                        .HasForeignKey("Identidad.Models.ModelUsuario.DomicilioME", "Id");

                    b.HasOne("Identidad.Models.ModelUsuario.MunicipioME", "Municipio")
                        .WithMany()
                        .HasForeignKey("MunicipioId");

                    b.HasOne("Identidad.Models.ModelUsuario.PaisME", "Pais")
                        .WithMany()
                        .HasForeignKey("PaisId");

                    b.Navigation("Departamento");

                    b.Navigation("Municipio");

                    b.Navigation("Pais");

                    b.Navigation("Persona");
                });

            modelBuilder.Entity("Identidad.Models.ModelUsuario.LugarNacimientoME", b =>
                {
                    b.HasOne("Identidad.Models.ModelUsuario.DepartamentoME", "Departamento")
                        .WithMany()
                        .HasForeignKey("DepartamentoId");

                    b.HasOne("Identidad.Models.ModelUsuario.PersonaME", "Persona")
                        .WithOne("LugarNacimiento")
                        .HasForeignKey("Identidad.Models.ModelUsuario.LugarNacimientoME", "Id");

                    b.HasOne("Identidad.Models.ModelUsuario.MunicipioME", "Municipio")
                        .WithMany()
                        .HasForeignKey("MunicipioId");

                    b.HasOne("Identidad.Models.ModelUsuario.PaisME", "Pais")
                        .WithMany()
                        .HasForeignKey("PaisId");

                    b.Navigation("Departamento");

                    b.Navigation("Municipio");

                    b.Navigation("Pais");

                    b.Navigation("Persona");
                });

            modelBuilder.Entity("Identidad.Models.ModelUsuario.MunicipioME", b =>
                {
                    b.HasOne("Identidad.Models.ModelUsuario.DepartamentoME", "Departamento")
                        .WithMany("Municipios")
                        .HasForeignKey("DepartamentoId");

                    b.Navigation("Departamento");
                });

            modelBuilder.Entity("Identidad.Models.ModelUsuario.PersonaME", b =>
                {
                    b.HasOne("Identidad.Models.ModelUsuario.EstatusME", "Estatus")
                        .WithMany()
                        .HasForeignKey("EstatusId");

                    b.HasOne("Identidad.Models.ModelUsuario.GrupoSanguineoME", "RH")
                        .WithMany()
                        .HasForeignKey("RHGrupoSanguineoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Identidad.Models.ModelUsuario.TipoDocumentoME", "TipoDocumento")
                        .WithMany()
                        .HasForeignKey("TipoDocumentoId");

                    b.Navigation("Estatus");

                    b.Navigation("RH");

                    b.Navigation("TipoDocumento");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Identidad.Models.AppUsuario", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Identidad.Models.AppUsuario", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Identidad.Models.AppUsuario", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Identidad.Models.AppUsuario", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Identidad.Models.ModelUsuario.DepartamentoME", b =>
                {
                    b.Navigation("Municipios");
                });

            modelBuilder.Entity("Identidad.Models.ModelUsuario.PaisME", b =>
                {
                    b.Navigation("Departamentos");
                });

            modelBuilder.Entity("Identidad.Models.ModelUsuario.PersonaME", b =>
                {
                    b.Navigation("Domicilio");

                    b.Navigation("LugarNacimiento");
                });
#pragma warning restore 612, 618
        }
    }
}
