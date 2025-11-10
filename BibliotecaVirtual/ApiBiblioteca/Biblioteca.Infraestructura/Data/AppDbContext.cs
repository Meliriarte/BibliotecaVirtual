using Biblioteca.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Infraestructura.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Editorial> Editoriales { get; set; }
        public DbSet<Libro> Libros { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Confirguracion de Editorial
            modelBuilder.Entity<Editorial>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Nombre).IsRequired().HasMaxLength(200);
                entity.Property(e => e.Pais).HasMaxLength(100);
                entity.Property(e => e.FechaRegistro).IsRequired();
            });

            // Configuracion de Libro
            modelBuilder.Entity<Libro>(entity => {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Titulo).IsRequired().HasMaxLength(300);
                entity.Property(e => e.Autor).IsRequired().HasMaxLength(200);
                entity.Property(e => e.AnioPublicacion).IsRequired();
                entity.Property(e => e.Genero).IsRequired();
                // Relacion entre Libro y Editorial
                entity.HasOne<Editorial>()
                      .WithMany(e => e.Libros)
                      .HasForeignKey(e => e.EditorialId);
            });
        }
    }
}