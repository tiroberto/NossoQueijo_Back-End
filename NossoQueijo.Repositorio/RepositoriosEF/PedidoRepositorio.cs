using Microsoft.EntityFrameworkCore;
using NossoQueijo.Dominio.Entidades;
using NossoQueijo.Dominio.Interfaces.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace NossoQueijo.Repositorio.RepositoriosEF
{
    public class  PedidoRepositorio : RepositorioBase<Pedido> , IPedidoRepositorio
    {
        private Contexto _contexto;

        public PedidoRepositorio()
        {
            _contexto = new Contexto();
        }

        public IEnumerable<Pedido> ListarTodos()
        {
            return _contexto.Pedidos
                .Include(x => x.FormaPagamento)
                .Include(x => x.Status)
                .Include(x => x.Usuario)
                .ThenInclude(y => y.Endereco)
                .ThenInclude(y => y.Cidade)
                .ThenInclude(y => y.Estado)
                .ToList();
        }

        public IEnumerable<Pedido> ListarPorIdUsuario(int idUsuario)
        {
            return _contexto.Pedidos
                .Where(x => x.Usuario.idUsuario == idUsuario)
                .ToList();
        }

        public IEnumerable<Pedido> ListarPorIdStatus(int idStatus)
        {
            return _contexto.Pedidos
                .Where(x => x.Status.idStatus == idStatus)
                .ToList();
        }

        public IEnumerable<Pedido> ListarPorIdFormaPagamento(int idFormaPagamento)
        {
            return _contexto.Pedidos
                .Where(x => x.FormaPagamento.idFormaPagamento == idFormaPagamento)
                .ToList();
        }

        public Pedido BuscarPorId(int id)
        {
            return _contexto.Pedidos
                .Include(x => x.FormaPagamento)
                .Include(x => x.Status)
                .Include(x => x.Usuario)
                .ThenInclude(y => y.Endereco)
                .ThenInclude(y => y.Cidade)
                .ThenInclude(y => y.Estado)
                .First(x => x.idPedido == id);
                
        }

        public bool RemoverPersonalizado(int id)
        {
            Pedido pedidoRemover = _contexto.Pedidos.First(x => x.idPedido == id);
            IEnumerable<PedidoProduto> pedidoProdutosRemover = _contexto.PedidoProdutos.Where(x => x.Pedido.idPedido == id);
            _contexto.PedidoProdutos.RemoveRange(pedidoProdutosRemover);
            _contexto.Pedidos.Remove(pedidoRemover);
            _contexto.SaveChanges();
            return true;
        }
    }
}
