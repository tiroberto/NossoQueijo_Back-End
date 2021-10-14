using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Text;
using NossoQueijo.Dominio.Entidades;

namespace NossoQueijo.Repositorio.Configuracoes
{
    class PedidoProdutoConfiguracao : IEntityTypeConfiguration<PedidoProduto>
    {
        public void Configure(EntityTypeBuilder<PedidoProduto> builder)
        {
            builder.ToTable("PedidoProduto", "dbo");
            builder.HasKey("idProduto","idPedido");
            builder.Property(i => i.Quantidade)
                .HasColumnName("Quantidade");
            builder.HasOne(i => i.Produto)
                .WithMany(j => j.PedidoProdutos)
                .HasForeignKey(j => j.idProduto);
            builder.HasOne(i => i.Pedido)
                .WithMany(j => j.PedidoProdutos)
                .HasForeignKey(j => j.idPedido);
        }
    }
}
