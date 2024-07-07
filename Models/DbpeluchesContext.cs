using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TareasAPI.Models
{
    public partial class DbpeluchesContext : DbContext
    {
        public DbpeluchesContext()
        {
        }

        public DbpeluchesContext(DbContextOptions<DbpeluchesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Peluche> Peluches { get; set; }
        public virtual DbSet<Categoria> Categorias { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Configuración opcional
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Peluche>(entity =>
            {
                entity.HasKey(e => e.IdPeluche).HasName("PK__Peluche__756A5402A76F7C50");

                entity.ToTable("Peluche");

                entity.Property(e => e.IdPeluche).HasColumnName("idPeluche");
                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
                entity.Property(e => e.Precio)
                    .HasColumnName("precio");
                entity.Property(e => e.Descripcion)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");
                entity.Property(e => e.Imagen)
                    .IsUnicode(false)
                    .HasColumnName("imagen");

                entity.Property(e => e.IdCategoria).HasColumnName("idCategoria");

                entity.HasOne(d => d.Categoria)
                    .WithMany(p => p.Peluches)
                    .HasForeignKey(d => d.IdCategoria)
                    .HasConstraintName("FK_Categoria");
            });

            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.HasKey(e => e.IdCategoria).HasName("PK__Categori__8A3D240CEBAF8F5E");

                entity.ToTable("Categoria");

                entity.Property(e => e.IdCategoria).HasColumnName("idCategoria");
                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
