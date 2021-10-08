using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Text;
using NossoQueijo.Dominio.Entidades;

namespace NossoQueijo.Repositorio.Configuracoes
{
    class UsuarioConfiguracao : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("usuario", "nossoqueijo");
            builder.HasKey("idUsuario");
            builder.Property(i => i.Nome)
                .HasMaxLength(150)
                .HasColumnName("Nome");
            builder.Property(i => i.CPF)
                .HasMaxLength(11)
                .HasColumnName("CPF");
            builder.Property(i => i.Email)
                .HasMaxLength(50)
                .HasColumnName("Email");
            builder.Property(i => i.Senha)
                .HasMaxLength(20)
                .HasColumnName("Senha");
            builder.Property(i => i.DataNascimento)
                .HasColumnName("DataNascimento");
            builder.HasOne(i => i.Endereco)
                .WithOne(j => j.Usuario)
                .HasForeignKey<Endereco>(j => j.idEndereco);
            builder.HasOne(i => i.TipoUsuario)
                .WithMany(j => j.Usuarios);
            builder.HasMany(i => i.Pedidos)
                .WithOne(j => j.Usuario);
        }
    }
}
