using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Text;
using NossoQueijo.Dominio.Entidades;

namespace NossoQueijo.Repositorio.Configuracoes
{
    class ProdutoConfiguracao : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("produto", "nossoqueijo");
            builder.HasKey("idProduto");
            builder.Property(i => i.Nome)
                .HasMaxLength(150)
                .HasColumnName("Nome");
            builder.Property(i => i.QntdEstoque)
                .HasColumnName("QntdEstoque");
            builder.Property(i => i.Preco)
                .HasColumnName("Preco");
            builder.Property(i => i.Peso)
                .HasColumnName("Peso");
            builder.HasMany(i => i.EstoquePorDatas)
                .WithOne(j => j.Produto);
        }
    }
}
