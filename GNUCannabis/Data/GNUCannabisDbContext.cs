using System;
using System.Collections.Generic;
using GNUCannabis.Models;
using Microsoft.EntityFrameworkCore;

namespace GNUCannabis.Data;

public partial class GNUCannabisDbContext : DbContext
{
    public GNUCannabisDbContext()
    {
    }

    public GNUCannabisDbContext(DbContextOptions<GNUCannabisDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cultivo> Cultivos { get; set; }

    public virtual DbSet<EstadosPlanta> EstadosPlanta { get; set; }

    public virtual DbSet<HistorialPlanta> HistorialPlanta { get; set; }

    public virtual DbSet<Persona> Personas { get; set; }

    public virtual DbSet<Planta> Plantas { get; set; }

    public virtual DbSet<Rol> Roles { get; set; }

    public virtual DbSet<TiposCultivo> TiposCultivos { get; set; }

    public virtual DbSet<TiposDocumento> TiposDocumentos { get; set; }

    public virtual DbSet<TiposPlanta> TiposPlanta { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cultivo>(entity =>
        {
            entity.HasKey(e => e.IdCultivo).HasName("PK__Cultivos__594DD7D257FACE6A");

            entity.Property(e => e.Nombre).HasMaxLength(100);

            entity.HasOne(d => d.IdTipoCultivoNavigation).WithMany(p => p.Cultivos)
                .HasForeignKey(d => d.IdTipoCultivo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Cultivos__IdTipo__440B1D61");
        });

        modelBuilder.Entity<EstadosPlanta>(entity =>
        {
            entity.HasKey(e => e.IdEstadoPlanta).HasName("PK__EstadosP__B3829EEFD1577DBC");

            entity.HasIndex(e => e.NombreEstado, "UQ__EstadosP__6CE50615BFEA10F8").IsUnique();

            entity.Property(e => e.NombreEstado).HasMaxLength(30);
        });

        modelBuilder.Entity<HistorialPlanta>(entity =>
        {
            entity.HasKey(e => e.IdHistorial).HasName("PK__Historia__9CC7DBB4D8C63244");

            entity.Property(e => e.Fecha)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.IdPlantaNavigation).WithMany(p => p.HistorialPlanta)
                .HasForeignKey(d => d.IdPlanta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Historial__IdPla__5812160E");
        });

        modelBuilder.Entity<Persona>(entity =>
        {
            entity.HasKey(e => e.IdPersona).HasName("PK__Personas__2EC8D2ACB26BF1EB");

            entity.HasIndex(e => e.NumeroDocumento, "UQ__Personas__A42025886F43A378").IsUnique();

            entity.Property(e => e.NombreCompleto).HasMaxLength(100);
            entity.Property(e => e.NumeroDocumento).HasMaxLength(30);

            entity.HasOne(d => d.IdTipoDocumentoNavigation).WithMany(p => p.Personas)
                .HasForeignKey(d => d.IdTipoDocumento)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Personas__IdTipo__3B75D760");
        });

        modelBuilder.Entity<Planta>(entity =>
        {
            entity.HasKey(e => e.IdPlanta).HasName("PK__Plantas__12FEC1244401E291");

            entity.Property(e => e.Nombre).HasMaxLength(100);

            entity.HasOne(d => d.IdCultivoNavigation).WithMany(p => p.Planta)
                .HasForeignKey(d => d.IdCultivo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Plantas__IdCulti__52593CB8");

            entity.HasOne(d => d.IdEstadoPlantaNavigation).WithMany(p => p.Planta)
                .HasForeignKey(d => d.IdEstadoPlanta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Plantas__IdEstad__5441852A");

            entity.HasOne(d => d.IdTipoPlantaNavigation).WithMany(p => p.Planta)
                .HasForeignKey(d => d.IdTipoPlanta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Plantas__IdTipoP__534D60F1");
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.IdRol).HasName("PK__Roles__2A49584C2681B80D");

            entity.HasIndex(e => e.NombreRol, "UQ__Roles__4F0B537F06409730").IsUnique();

            entity.Property(e => e.NombreRol).HasMaxLength(20);
        });

        modelBuilder.Entity<TiposCultivo>(entity =>
        {
            entity.HasKey(e => e.IdTipoCultivo).HasName("PK__TiposCul__7FD6CA4F83BBDE55");

            entity.ToTable("TiposCultivo");

            entity.HasIndex(e => e.NombreTipo, "UQ__TiposCul__7586661C2B9B14DC").IsUnique();

            entity.Property(e => e.NombreTipo).HasMaxLength(30);
        });

        modelBuilder.Entity<TiposDocumento>(entity =>
        {
            entity.HasKey(e => e.IdTipoDocumento).HasName("PK__TiposDoc__3AB3332F7120B4EF");

            entity.ToTable("TiposDocumento");

            entity.HasIndex(e => e.NombreTipo, "UQ__TiposDoc__7586661C08E6F5FE").IsUnique();

            entity.Property(e => e.NombreTipo).HasMaxLength(30);
        });

        modelBuilder.Entity<TiposPlanta>(entity =>
        {
            entity.HasKey(e => e.IdTipoPlanta).HasName("PK__TiposPla__FB32ABE44704C2EC");

            entity.HasIndex(e => e.NombreTipo, "UQ__TiposPla__7586661CB7D70C8A").IsUnique();

            entity.Property(e => e.NombreTipo).HasMaxLength(30);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__Usuarios__5B65BF97A4D1336E");

            entity.HasIndex(e => e.Correo, "UQ__Usuarios__60695A19BFF0B6A1").IsUnique();

            entity.Property(e => e.ContrasenaHash).HasMaxLength(200);
            entity.Property(e => e.Correo).HasMaxLength(100);

            entity.HasOne(d => d.IdCultivoNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdCultivo)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK__Usuarios__IdCult__49C3F6B7");

            entity.HasOne(d => d.IdPersonaNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdPersona)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Usuarios__IdPers__47DBAE45");

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdRol)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Usuarios__IdRol__48CFD27E");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
