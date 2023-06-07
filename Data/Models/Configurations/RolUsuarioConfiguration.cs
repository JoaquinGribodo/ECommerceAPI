﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace Data.Models.Configurations
{
    public partial class RolUsuarioConfiguration : IEntityTypeConfiguration<RolUsuario>
    {
        public void Configure(EntityTypeBuilder<RolUsuario> entity)
        {
            entity.ToTable("Rol_usuario");

            entity.Property(e => e.Id).HasColumnName("id");

            entity.Property(e => e.Descripcion)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("descripcion");

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<RolUsuario> entity);
    }
}
