using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Text;
using NossoQueijo.Dominio.Entidades;

namespace NossoQueijo.Repositorio.Configuracoes
{
    class FormaPagamentoConfiguracao : IEntityTypeConfiguration<FormaPagamento>
    {
        public void Configure(EntityTypeBuilder<FormaPagamento> builder)
        {
            builder.ToTable("FormaPagamento", "dbo");
            builder.HasKey("idFormaPagamento");
            builder.Property(i => i.Descricao)
                .HasMaxLength(150)
                .HasColumnName("Descricao");
            builder.Property(i => i.Imagem)
                .HasColumnName("Imagem");
        }
    }
}
