﻿using IFSPStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IFSPStory.Repository.Mapping
{
    public class GrupoMap : IEntityTypeConfiguration<Grupo>
    {
        public void Configure(EntityTypeBuilder<Grupo> builder)
        {
            builder.ToTable("Grupo");

            builder.HasKey(prop => prop.Id);

            builder.Property(prop => prop.Nome)
                .HasColumnName("Nome")
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}
