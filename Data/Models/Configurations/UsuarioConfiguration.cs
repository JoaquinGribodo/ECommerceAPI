﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace Data.Models.Configurations
{
    public partial class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> entity)
        {
            entity.Property(e => e.Id).HasColumnName("id");

            entity.Property(e => e.Apellido)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("apellido");

            entity.Property(e => e.Contrasenia)
                .IsRequired()
                .HasMaxLength(256)
                .IsUnicode(false)
                .HasColumnName("contrasenia");

            entity.Property(e => e.Correo)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("correo");

            entity.Property(e => e.IdRol).HasColumnName("id_rol");

            entity.Property(e => e.Nombre)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("nombre");

            entity.HasOne(d => d.IdRolNavigation)
                .WithMany(p => p.Usuario)
                .HasForeignKey(d => d.IdRol)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Usuario__id_rol__267ABA7A");

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<Usuario> entity);
    }
}
