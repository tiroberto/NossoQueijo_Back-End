using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Text;
using NossoQueijo.Dominio.Entidades;

namespace NossoQueijo.Repositorio.Configuracoes
{
    class CidadeConfiguracao : IEntityTypeConfiguration<Cidade>
    {
        public void Configure(EntityTypeBuilder<Cidade> builder)
        {
            builder.ToTable("cidade", "nossoqueijo");
            builder.HasKey("idCidade");
            builder.Property(i => i.Nome)
                .HasMaxLength(150)
                .HasColumnName("Nome");
            builder.HasOne(i => i.Estado)
                .WithMany(j => j.Cidades);
            builder.HasMany(i => i.Enderecos)
                .WithOne(j => j.Cidade);
        }
    }
}
