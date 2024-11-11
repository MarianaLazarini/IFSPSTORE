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
    public class GrupoMap : IEntityTypeConfiguration<Grupo>
    {
        public void Configure(EntityTypeBuilder<Grupo> builder)
        {
            //define o nome da tabela
            builder.ToTable("Abobrinha");
            //define a chave primária
            builder.HasKey(x => x.Id);

            builder.Property(prop => prop.Nome)
                .HasColumnName("Melancia")
                .IsRequired()
                .HasMaxLength(50);
            //.HasColumnType("varchar(50)");
        }
    }
}
