using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Text;
using NossoQueijo.Dominio.Entidades;

namespace NossoQueijo.Repositorio.Configuracoes
{
    class StatusConfiguracao : IEntityTypeConfiguration<Status>
    {
        public void Configure(EntityTypeBuilder<Status> builder)
        {
            builder.ToTable("Status", "dbo");
            builder.HasKey("idStatus");
            builder.Property(i => i.Descricao)
                .HasMaxLength(150)
                .HasColumnName("Descricao");
            builder.HasMany(i => i.Pedidos)
                .WithOne(j => j.Status);
        }
    }
}
