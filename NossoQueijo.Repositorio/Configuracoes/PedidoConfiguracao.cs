using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Text;
using NossoQueijo.Dominio.Entidades;

namespace NossoQueijo.Repositorio.Configuracoes
{
    class PedidoConfiguracao : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.ToTable("Pedido", "dbo");
            builder.HasKey("idPedido");
            builder.Property(i => i.ValorFrete)
                .HasColumnName("ValorFrete");
            builder.Property(i => i.Data)
                .HasColumnName("Data")
                .HasColumnType("datetime");
            builder.HasOne(i => i.Usuario)
                .WithMany(j => j.Pedidos)
                .HasForeignKey("idUsuario");
            builder.HasOne(i => i.FormaPagamento)
                .WithMany(j => j.Pedidos)
                .HasForeignKey("idFormaPagamento");
            builder.HasOne(i => i.Status)
                .WithMany(j => j.Pedidos)
                .HasForeignKey("idStatus");
            builder.HasOne(i => i.EnderecoEntrega)
                .WithMany(j => j.Pedidos)
                .HasForeignKey("idEndereco");
            
        }
    }
}
