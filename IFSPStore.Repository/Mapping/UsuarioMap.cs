using IFSPStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFSPStore.Repository.Mapping
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuario");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(x => x.Senha)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(x => x.Email)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(x => x.Login)
                .IsRequired()
                .HasMaxLength(255);

        }
    }
}
