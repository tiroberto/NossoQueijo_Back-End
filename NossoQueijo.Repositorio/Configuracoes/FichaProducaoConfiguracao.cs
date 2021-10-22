using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NossoQueijo.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace NossoQueijo.Repositorio.Configuracoes
{
    class FichaProducaoConfiguracao : IEntityTypeConfiguration<FichaProducao>
    {
        public void Configure(EntityTypeBuilder<FichaProducao> builder)
        {
            builder.ToTable("FichaProducao", "dbo");
            builder.HasKey("idFichaProducao");
            builder.Property(i => i.Data)
                .HasColumnName("Data");
            builder.Property(i => i.VolumeCoalho)
                .HasColumnName("VolumeCoalho");
            builder.Property(i => i.VolumeLeite)
                .HasColumnName("VolumeLeite");
            builder.Property(i => i.VolumePingo)
                .HasColumnName("VolumePingo");
            builder.Property(i => i.QntdProduzida)
                .HasColumnName("QntdProduzida");
            builder.Property(i => i.QntdSal)
                .HasColumnName("QntdSal");
            builder.HasOne(i => i.Usuario)
                .WithMany(i => i.FichasProducao)
                .HasForeignKey("idUsuario");
            builder.HasOne(i => i.Produto)
                .WithMany(i => i.FichasProducao)
                .HasForeignKey("idProduto");

            builder.HasOne(i => i.EstoquePorData)
                .WithOne(i => i.FichaProducao)
                .HasForeignKey<EstoquePorData>(i => i.idFichaProducao);
        }
    }
}
