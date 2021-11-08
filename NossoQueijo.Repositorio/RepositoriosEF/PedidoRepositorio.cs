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

        public void AdicionarPersonalizado(Pedido pedido)
        {
            pedido.FormaPagamento = _contexto.FormasPagamento
                .First(x => x.idFormaPagamento == pedido.FormaPagamento.idFormaPagamento);
            pedido.Status = _contexto.Status
                .First(x => x.idStatus == pedido.Status.idStatus);
            pedido.Usuario = _contexto.Usuarios
                .First(x => x.idUsuario == pedido.Usuario.idUsuario);
            _contexto.Pedidos.Add(pedido);
            _contexto.SaveChanges();
        }

        public void AtualizarPersonalizado(Pedido pedido)
        {
            pedido.FormaPagamento = _contexto.FormasPagamento
                .First(x => x.idFormaPagamento == pedido.FormaPagamento.idFormaPagamento);
            pedido.Status = _contexto.Status
                .First(x => x.idStatus == pedido.Status.idStatus);
            pedido.Usuario = _contexto.Usuarios
                .First(x => x.idUsuario == pedido.Usuario.idUsuario);
            pedido.PedidoProdutos = null;
            _contexto.Pedidos.Update(pedido);
            _contexto.SaveChanges();
        }

        public Pedido UltimoAdicionado()
        {
            return _contexto.Pedidos
                .OrderByDescending(x => x.idPedido)
                .FirstOrDefault();
        }

        public IEnumerable<Pedido> ListarTodos()
        {
            return _contexto.Pedidos
                .Include(x => x.FormaPagamento)
                .Include(x => x.Status)
                .Include(x => x.PedidoProdutos)
                .Include(x => x.Usuario)
                .ToList();
        }

        public IEnumerable<Pedido> ListarPorIdUsuario(int idUsuario)
        {
            return _contexto.Pedidos
                .Include(x => x.FormaPagamento)
                .Include(x => x.Status)
                .Include(x => x.PedidoProdutos)
                .ThenInclude(x => x.Produto)
                .Where(x => x.Usuario.idUsuario == idUsuario)
                .ToList();
        }

        public IEnumerable<Pedido> ListarPorIdStatus(int idStatus)
        {
            return _contexto.Pedidos
                .Include(x => x.FormaPagamento)
                .Include(x => x.Status)
                .Include(x => x.PedidoProdutos)
                .Include(x => x.Usuario)
                .Where(x => x.Status.idStatus == idStatus)
                .ToList();
        }

        public IEnumerable<Pedido> ListarPorIdFormaPagamento(int idFormaPagamento)
        {
            return _contexto.Pedidos
                .Include(x => x.FormaPagamento)
                .Include(x => x.Status)
                .Include(x => x.PedidoProdutos)
                .Include(x => x.Usuario)
                .Where(x => x.FormaPagamento.idFormaPagamento == idFormaPagamento)
                .ToList();
        }

        public Pedido BuscarPorId(int id)
        {
            return _contexto.Pedidos
                .Include(x => x.FormaPagamento)
                .Include(x => x.Status)
                .Include(x => x.PedidoProdutos)
                .Include(x => x.Usuario)
                .First(x => x.idPedido == id);
                
        }

        public void RemoverPersonalizado(int id)
        {
            Pedido pedidoRemover = _contexto.Pedidos.First(x => x.idPedido == id);
            IEnumerable<PedidoProduto> pedidoProdutosRemover = _contexto.PedidoProdutos.Where(x => x.Pedido.idPedido == id).ToList();
            _contexto.PedidoProdutos.RemoveRange(pedidoProdutosRemover);
            _contexto.Pedidos.Remove(pedidoRemover);
            _contexto.SaveChanges();
        }
    }
}
