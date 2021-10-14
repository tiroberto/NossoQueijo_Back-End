using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Text;
using NossoQueijo.Dominio.Entidades;

namespace NossoQueijo.Repositorio.Configuracoes
{
    class EnderecoConfiguracao : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.ToTable("Endereco", "dbo");
            builder.HasKey("idEndereco");
            builder.Property(i => i.Rua)
                .HasMaxLength(150)
                .HasColumnName("Rua");
            builder.Property(i => i.Numero)
                .HasColumnName("Numero");
            builder.Property(i => i.Bairro)
                .HasMaxLength(150)
                .HasColumnName("Bairro");
            builder.Property(i => i.Complemento)
                .HasMaxLength(150)
                .HasColumnName("Complemento");
            builder.HasOne(i => i.Cidade)
                .WithMany(j => j.Enderecos)
                .HasForeignKey("idCidade");
            builder.HasOne(i => i.Usuario)
                .WithOne(j => j.Endereco)
                .HasForeignKey<Usuario>(j => j.idEndereco);
        }
    }
}
