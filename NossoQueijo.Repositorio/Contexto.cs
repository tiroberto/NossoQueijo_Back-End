using System;
using Microsoft.EntityFrameworkCore;
using NossoQueijo.Repositorio.Configuracoes;
using NossoQueijo.Dominio.Entidades;

namespace NossoQueijo.Repositorio
{
    public class Contexto : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<TipoUsuario> TiposUsuario { get; set; }
        public DbSet<Cidade> Cidades { get; set; }
        public DbSet<Estado> Estados { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<FichaProducao> FichasProducao { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<EstoquePorData> EstoquePorDatas { get; set; }
        public DbSet<PedidoProduto> PedidoProdutos { get; set; }
        public DbSet<FormaPagamento> FormasPagamento { get; set; }

        /*internal Usuario Include()
        {
            throw new NotImplementedException();
        }*/


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=database-1.chqmyt81tc2d.us-east-2.rds.amazonaws.com;database=nossoqueijo;user id=admin;password=zgY0mWAFojxviinJNpyf;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioConfiguracao());
            modelBuilder.ApplyConfiguration(new TipoUsuarioConfiguracao());
            modelBuilder.ApplyConfiguration(new CidadeConfiguracao());
            modelBuilder.ApplyConfiguration(new EstadoConfiguracao());
            modelBuilder.ApplyConfiguration(new EnderecoConfiguracao());
            modelBuilder.ApplyConfiguration(new StatusConfiguracao());
            modelBuilder.ApplyConfiguration(new FichaProducaoConfiguracao());
            modelBuilder.ApplyConfiguration(new ProdutoConfiguracao());
            modelBuilder.ApplyConfiguration(new PedidoConfiguracao());
            modelBuilder.ApplyConfiguration(new EstoquePorDataConfiguracao());
            modelBuilder.ApplyConfiguration(new PedidoProdutoConfiguracao());
            modelBuilder.ApplyConfiguration(new FormaPagamentoConfiguracao());
        }
    }
}
