using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace API_Prueba.Models
{
    public partial class repasoPContext : DbContext
    {
        public repasoPContext()
        {
        }

        public repasoPContext(DbContextOptions<repasoPContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Deporte> Deportes { get; set; } = null!;
        public virtual DbSet<Persona> Personas { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<Sexo> Sexos { get; set; } = null!;
        public virtual DbSet<TiposDeporte> TiposDeportes { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Server=localhost; Database=repasoP; Port=5432; User Id=valentina; Password=123456");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Deporte>(entity =>
            {
                entity.HasIndex(e => e.IdTipoDeporte, "fki_fk_tipoDeporte");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Descripcion).HasColumnName("descripcion");

                entity.Property(e => e.IdTipoDeporte).HasColumnName("id_tipoDeporte");

                entity.Property(e => e.Nombre).HasColumnName("nombre");

                entity.HasOne(d => d.IdTipoDeporteNavigation)
                    .WithMany(p => p.Deportes)
                    .HasForeignKey(d => d.IdTipoDeporte)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_tipoDeporte");
            });

            modelBuilder.Entity<Persona>(entity =>
            {
                entity.HasIndex(e => e.IdSexo, "fki_fk_sexo");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Apellido).HasColumnName("apellido");

                entity.Property(e => e.Calle).HasColumnName("calle");

                entity.Property(e => e.Dni).HasColumnName("dni");

                entity.Property(e => e.IdSexo).HasColumnName("id_sexo");

                entity.Property(e => e.Nombre).HasColumnName("nombre");

                entity.Property(e => e.Numero).HasColumnName("numero");

                entity.HasOne(d => d.IdSexoNavigation)
                    .WithMany(p => p.Personas)
                    .HasForeignKey(d => d.IdSexo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_sexo");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Descripcion).HasColumnName("descripcion");

                entity.Property(e => e.Rol).HasColumnName("rol");
            });

            modelBuilder.Entity<Sexo>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Sexo1).HasColumnName("sexo");
            });

            modelBuilder.Entity<TiposDeporte>(entity =>
            {
                entity.ToTable("TiposDeporte");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Tipo).HasColumnName("tipo");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasIndex(e => e.IdDeporte, "fki_fk_deporte");

                entity.HasIndex(e => e.IdPersona, "fki_fk_persona");

                entity.HasIndex(e => e.IdRol, "fki_fk_rol");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.FechaAlta).HasColumnName("fechaAlta");

                entity.Property(e => e.IdDeporte).HasColumnName("id_deporte");

                entity.Property(e => e.IdPersona).HasColumnName("id_persona");

                entity.Property(e => e.IdRol).HasColumnName("id_rol");

                entity.Property(e => e.Password).HasColumnName("password");

                entity.Property(e => e.Usuario1).HasColumnName("usuario");

                entity.HasOne(d => d.IdDeporteNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdDeporte)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_deporte");

                entity.HasOne(d => d.IdPersonaNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdPersona)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_persona");

                entity.HasOne(d => d.IdRolNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdRol)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_rol");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
