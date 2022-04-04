using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Text;
using NossoQueijo.Dominio.Entidades;

namespace NossoQueijo.Repositorio.Configuracoes
{
    class EstadoConfiguracao : IEntityTypeConfiguration<Estado>
    {
        public void Configure(EntityTypeBuilder<Estado> builder)
        {
            builder.ToTable("Estado", "dbo");
            builder.HasKey("idEstado");
            builder.Property(i => i.Nome)
                .HasMaxLength(150)
                .HasColumnName("Nome");
            builder.Property(i => i.UF)
                .HasMaxLength(2)
                .HasColumnName("UF");
        }
    }
}
