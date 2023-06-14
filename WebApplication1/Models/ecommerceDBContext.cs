using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace WebApplication1.Models
{
    public partial class ecommerceDBContext : DbContext
    {
        public ecommerceDBContext()
        {
        }

        public ecommerceDBContext(DbContextOptions<ecommerceDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Envio> Envios { get; set; } = null!;
        public virtual DbSet<Producto> Productos { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<Variante> Variantes { get; set; } = null!;
        public virtual DbSet<Venta> Ventas { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var config = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();
                string connectionString = config.GetConnectionString("ecommerceDBConnection");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Envio>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Destino)
                    .HasMaxLength(255)
                    .HasColumnName("destino");

                entity.Property(e => e.Origen)
                    .HasMaxLength(255)
                    .HasColumnName("origen");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Articulo)
                    .HasMaxLength(255)
                    .HasColumnName("articulo");

                entity.Property(e => e.Marca)
                    .HasMaxLength(255)
                    .HasColumnName("marca");

                entity.Property(e => e.Precio)
                    .HasMaxLength(255)
                    .HasColumnName("precio");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.Email, "UQ__Users__AB6E616494872115")
                    .IsUnique();

                entity.HasIndex(e => e.Tel, "UQ__Users__DC107AB3EC091362")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Dni).HasColumnName("DNI");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .HasColumnName("email");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(255)
                    .HasColumnName("nombre");

                entity.Property(e => e.Tel)
                    .HasMaxLength(255)
                    .HasColumnName("tel");
            });

            modelBuilder.Entity<Variante>(entity =>
            {
                entity.ToTable("Variante");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Color)
                    .HasMaxLength(255)
                    .HasColumnName("color");

                entity.Property(e => e.IdProducto).HasColumnName("id_producto");

                entity.Property(e => e.Talle)
                    .HasMaxLength(255)
                    .HasColumnName("talle");

                entity.HasOne(d => d.IdProductoNavigation)
                    .WithMany(p => p.Variantes)
                    .HasForeignKey(d => d.IdProducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Variante__id_pro__49C3F6B7");
            });

            modelBuilder.Entity<Venta>(entity =>
            {
                entity.HasKey(e => e.IdVenta)
                    .HasName("PK__Ventas__459533BF730952AE");

                entity.Property(e => e.IdVenta).HasColumnName("id_venta");

                entity.Property(e => e.IdEnvio).HasColumnName("id_envio");

                entity.Property(e => e.IdProducto).HasColumnName("id_producto");

                entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

                entity.HasOne(d => d.IdEnvioNavigation)
                    .WithMany(p => p.Venta)
                    .HasForeignKey(d => d.IdEnvio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Ventas__id_envio__4CA06362");

                entity.HasOne(d => d.IdProductoNavigation)
                    .WithMany(p => p.Venta)
                    .HasForeignKey(d => d.IdProducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Ventas__id_produ__4E88ABD4");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Venta)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Ventas__id_usuar__4D94879B");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
