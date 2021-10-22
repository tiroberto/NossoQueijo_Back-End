using Microsoft.EntityFrameworkCore;
using NossoQueijo.Dominio.Entidades;
using NossoQueijo.Dominio.Interfaces.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace NossoQueijo.Repositorio.RepositoriosEF
{
    public class  PedidoProdutoRepositorio : RepositorioBase<PedidoProduto> , IPedidoProdutoRepositorio
    {
        private Contexto _contexto;

        public PedidoProdutoRepositorio()
        {
            _contexto = new Contexto();
        }

        public void AdicionarEmMassa(IEnumerable<PedidoProduto> pedidoProdutos)
        {
            _contexto.PedidoProdutos
                .AddRange(pedidoProdutos);
            _contexto.SaveChanges();
        }

        public void AtualizarEmMassa(IEnumerable<PedidoProduto> pedidoProdutos)
        {
            _contexto.PedidoProdutos
                .UpdateRange(pedidoProdutos);
            _contexto.SaveChanges();
        }

        public IEnumerable<PedidoProduto> ListarTodos()
        {
            return _contexto.PedidoProdutos
                .Include(x=>x.Pedido)
                .ThenInclude(y=>y.FormaPagamento)
                .Include(x=>x.Pedido)
                .ThenInclude(y=>y.Status)
                .Include(x=>x.Produto)
                .ToList();
        }

        public IEnumerable<PedidoProduto> ListarPorIdPedido(int idPedido)
        {
            return _contexto.PedidoProdutos
                .Where(x => x.idPedido == idPedido)
                .ToList();
        }
    }
}
