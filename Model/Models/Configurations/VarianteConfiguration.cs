﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Models;
using System;
using System.Collections.Generic;

namespace Model.Models.Configurations
{
    public partial class VarianteConfiguration : IEntityTypeConfiguration<Variante>
    {
        public void Configure(EntityTypeBuilder<Variante> entity)
        {
            entity.Property(e => e.Id).HasColumnName("id");

            entity.Property(e => e.Color)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("color");

            entity.Property(e => e.IdProducto).HasColumnName("id_producto");

            entity.Property(e => e.Talle)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("talle");

            entity.HasOne(d => d.IdProductoNavigation)
                .WithMany(p => p.Variante)
                .HasForeignKey(d => d.IdProducto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Variante__id_pro__3F466844");

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<Variante> entity);
    }
}
