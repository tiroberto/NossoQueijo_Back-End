using Canducci.Pagination;
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

        public int AdicionarPersonalizado(Pedido pedido)
        {
            pedido.FormaPagamento = _contexto.FormasPagamento
                .First(x => x.idFormaPagamento == pedido.FormaPagamento.idFormaPagamento);
            pedido.EnderecoEntrega = _contexto.Enderecos
                .First(x => x.idEndereco == pedido.EnderecoEntrega.idEndereco);
            pedido.Status = _contexto.Status
                .First(x => x.idStatus == pedido.Status.idStatus);
            pedido.Usuario = _contexto.Usuarios
                .First(x => x.idUsuario == pedido.Usuario.idUsuario);
            _contexto.Pedidos.Add(pedido);
            _contexto.SaveChanges();

            return pedido.idPedido;
        }

        public void AtualizarPersonalizado(Pedido pedido)
        {
            pedido.FormaPagamento = _contexto.FormasPagamento
                .First(x => x.idFormaPagamento == pedido.FormaPagamento.idFormaPagamento);
            pedido.EnderecoEntrega = _contexto.Enderecos
                .First(x => x.idEndereco == pedido.EnderecoEntrega.idEndereco);
            pedido.Status = _contexto.Status
                .First(x => x.idStatus == pedido.Status.idStatus);
            pedido.PedidoProdutos = null;
            pedido.Usuario = null;
            _contexto.Pedidos.Update(pedido);
            _contexto.SaveChanges();
        }

        public Pedido UltimoAdicionado()
        {
            return _contexto.Pedidos
                .OrderByDescending(x => x.idPedido)
                .FirstOrDefault();
        }

        public dynamic ListarTodosPaginado(int pagina)
        {
            return _contexto.Pedidos
                .Include(x => x.EnderecoEntrega)
                .ThenInclude(x => x.Cidade)
                .ThenInclude(x => x.Estado)
                .Select(x => new Pedido
                {
                    idPedido = x.idPedido,
                    ValorFrete = x.ValorFrete,
                    Usuario = x.Usuario,
                    FormaPagamento = x.FormaPagamento,
                    Status = x.Status,
                    PedidoProdutos = x.PedidoProdutos.Select(c => new PedidoProduto
                    {
                        idPedido = c.idPedido,
                        idProduto = c.idProduto,
                        Produto = c.Produto,
                        Pedido = null,
                        Quantidade = c.Quantidade
                    })
                })
                .AsNoTracking()
                .OrderBy(x => x.Data)
                .ToPaginatedRest(pagina, 10);
        }

        public IEnumerable<Pedido> ListarTodos()
        {
            return _contexto.Pedidos
                .Include(x => x.EnderecoEntrega)
                .ThenInclude(x => x.Cidade)
                .ThenInclude(x => x.Estado)
                .Select(x => new Pedido
                {
                    idPedido = x.idPedido,
                    ValorFrete = x.ValorFrete,
                    Usuario = x.Usuario,
                    FormaPagamento = x.FormaPagamento,
                    Status = x.Status,
                    PedidoProdutos = x.PedidoProdutos.Select(c => new PedidoProduto
                    {
                        idPedido = c.idPedido,
                        idProduto = c.idProduto,
                        Produto = c.Produto,
                        Pedido = null,
                        Quantidade = c.Quantidade
                    })
                })
                .AsNoTracking()
                .OrderBy(x => x.Data)
                .ToList();
        }

        public dynamic ListarPorPeriodoPaginado(DateTime inicio, DateTime fim, int pagina)
        {

            return _contexto.Pedidos
                .Include(x => x.EnderecoEntrega)
                .ThenInclude(x => x.Cidade)
                .ThenInclude(x => x.Estado)
                .Select(x => new Pedido
                {
                    idPedido = x.idPedido,
                    ValorFrete = x.ValorFrete,
                    Data = x.Data,
                    Usuario = x.Usuario,
                    FormaPagamento = x.FormaPagamento,
                    Status = x.Status,
                    EnderecoEntrega = x.EnderecoEntrega,
                    PedidoProdutos = x.PedidoProdutos.Select(c => new PedidoProduto
                    {
                        idPedido = c.idPedido,
                        idProduto = c.idProduto,
                        Produto = c.Produto,
                        Pedido = null,
                        Quantidade = c.Quantidade
                    })
                })
                .AsNoTracking()
                .OrderBy(x => x.Data)
                .Where(x => (x.Data >= inicio) && (x.Data <= fim))
                .ToPaginatedRest(pagina, 10);
        }

        public dynamic ListarPorIdUsuarioPaginado(int idUsuario, int pagina)
        {
            return _contexto.Pedidos
                .Include(x => x.EnderecoEntrega)
                .ThenInclude(x => x.Cidade)
                .ThenInclude(x => x.Estado)
                .Select(x => new Pedido
                {
                    idPedido = x.idPedido,
                    ValorFrete = x.ValorFrete,
                    Data = x.Data,
                    Usuario = x.Usuario,
                    FormaPagamento = x.FormaPagamento,
                    Status = x.Status,
                    EnderecoEntrega = x.EnderecoEntrega,
                    PedidoProdutos = x.PedidoProdutos.Select(c => new PedidoProduto
                    {
                        idPedido = c.idPedido,
                        idProduto = c.idProduto,
                        Produto = c.Produto,
                        Pedido = null,
                        Quantidade = c.Quantidade
                    })
                })
                .AsNoTracking()
                .OrderBy(x => x.Data)
                .Where(x => x.Usuario.idUsuario == idUsuario)
                .ToPaginatedRest(pagina, 10);
        }

        public dynamic ListarPorIdStatusPaginado(int idStatus, int pagina)
        {
            return _contexto.Pedidos
                .Include(x => x.EnderecoEntrega)
                .ThenInclude(x => x.Cidade)
                .ThenInclude(x => x.Estado)
                .Select(x => new Pedido
                {
                    idPedido = x.idPedido,
                    ValorFrete = x.ValorFrete,
                    Data = x.Data,
                    Usuario = x.Usuario,
                    FormaPagamento = x.FormaPagamento,
                    Status = x.Status,
                    EnderecoEntrega = x.EnderecoEntrega,
                    PedidoProdutos = x.PedidoProdutos.Select(c => new PedidoProduto
                    {
                        idPedido = c.idPedido,
                        idProduto = c.idProduto,
                        Produto = c.Produto,
                        Pedido = null,
                        Quantidade = c.Quantidade
                    })
                })
                .AsNoTracking()
                .OrderBy(x => x.Data)
                .Where(x => x.Status.idStatus == idStatus)
                .ToPaginatedRest(pagina, 10);
        }

        public dynamic ListarPorIdFormaPagamentoPaginado(int idFormaPagamento, int pagina)
        {
            return _contexto.Pedidos
                .Include(x => x.EnderecoEntrega)
                .ThenInclude(x => x.Cidade)
                .ThenInclude(x => x.Estado)
                .Select(x => new Pedido
                {
                    idPedido = x.idPedido,
                    ValorFrete = x.ValorFrete,
                    Data = x.Data,
                    Usuario = x.Usuario,
                    FormaPagamento = x.FormaPagamento,
                    Status = x.Status,
                    EnderecoEntrega = x.EnderecoEntrega,
                    PedidoProdutos = x.PedidoProdutos.Select(c => new PedidoProduto
                    {
                        idPedido = c.idPedido,
                        idProduto = c.idProduto,
                        Produto = c.Produto,
                        Pedido = null,
                        Quantidade = c.Quantidade
                    })
                })
                .AsNoTracking()
                .OrderBy(x => x.Data)
                .Where(x => x.FormaPagamento.idFormaPagamento == idFormaPagamento)
                .ToPaginatedRest(pagina, 10);
        }

        public Pedido BuscarPorId(int id)
        {
            return _contexto.Pedidos
                .Include(x => x.EnderecoEntrega)
                .ThenInclude(x => x.Cidade)
                .ThenInclude(x => x.Estado)
                .Select(x => new Pedido
                {
                    idPedido = x.idPedido,
                    ValorFrete = x.ValorFrete,
                    Data = x.Data,
                    Usuario = x.Usuario,
                    FormaPagamento = x.FormaPagamento,
                    Status = x.Status,
                    EnderecoEntrega = x.EnderecoEntrega,
                    PedidoProdutos = x.PedidoProdutos.Select(c => new PedidoProduto
                    {
                        idPedido = c.idPedido,
                        idProduto = c.idProduto,
                        Produto = c.Produto,
                        Pedido = null,
                        Quantidade = c.Quantidade
                    })
                })
                .First(x => x.idPedido == id);
        }

        public void RemoverPersonalizado(int id)
        {
            Pedido pedidoRemover = _contexto.Pedidos.First(x => x.idPedido == id);
            IEnumerable<PedidoProduto> pedidoProdutosRemover = _contexto.PedidoProdutos.Where(x => x.Pedido.idPedido == id);
            _contexto.PedidoProdutos.RemoveRange(pedidoProdutosRemover);
            _contexto.Pedidos.Remove(pedidoRemover);
            _contexto.SaveChanges();
        }
    }
}
