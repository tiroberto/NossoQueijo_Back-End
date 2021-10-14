using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Text;
using NossoQueijo.Dominio.Entidades;

namespace NossoQueijo.Repositorio.Configuracoes
{
    class EstoquePorDataConfiguracao : IEntityTypeConfiguration<EstoquePorData>
    {
        public void Configure(EntityTypeBuilder<EstoquePorData> builder)
        {
            builder.ToTable("EstoquePorData", "dbo");
            //builder.HasKey(i => new { i.idEstoquePorData, i.idProduto });
            builder.HasKey("idEstoquePorData", "idProduto");
            builder.Property(i => i.Quantidade)
                .HasColumnName("Quantidade");
            builder.HasOne(i => i.FichaProducao)
                .WithOne(j => j.EstoquePorData)
                .HasForeignKey<EstoquePorData>(j => j.idFichaProducao);
            builder.HasOne(i => i.Produto)
                 .WithMany()
                 .HasForeignKey(j => j.idProduto);
        }
    }
}
