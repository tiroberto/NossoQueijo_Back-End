using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Text;
using NossoQueijo.Dominio.Entidades;

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
            builder.Property(i => i.VolumeLeite)
                .HasColumnName("VolumeLeite");
            builder.Property(i => i.VolumeCoalho)
                .HasColumnName("VolumeCoalho");
            builder.Property(i => i.VolumePingo)
                .HasColumnName("VolumePingo");
            builder.Property(i => i.QntdSal)
                .HasColumnName("QntdSal");
            builder.Property(i => i.QntdProduzida)
                .HasColumnName("QntdProduzida");
            builder.HasOne(i => i.Usuario)
                .WithMany(j => j.FichasProducao);
        }
    }
}
