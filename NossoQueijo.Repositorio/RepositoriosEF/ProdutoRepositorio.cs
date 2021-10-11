using NossoQueijo.Dominio.Entidades;
using NossoQueijo.Dominio.Interfaces.Repositorio;
using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace NossoQueijo.Repositorio.RepositoriosEF
{
    public class  ProdutoRepositorio : RepositorioBase<Produto> , IProdutoRepositorio
    {
        private Contexto _contexto;

        public ProdutoRepositorio()
        {
            _contexto = new Contexto();
        }

        public IEnumerable<Produto> ListarTodos()
        {
            return _contexto.Produtos
                .ToList();
        }

        public Produto BuscarPorId(int id)
        {
            return _contexto.Produtos
                .First(x => x.idProduto == id);
        }

        public bool RemoverPersonalizado(int id)
        {
            Produto produtoRemover = _contexto.Produtos.First(x => x.idProduto == id);
            IEnumerable<PedidoProduto> pedidoProdutosRemover = _contexto.PedidoProdutos.Where(x => x.Produto.idProduto == id);
            _contexto.PedidoProdutos.RemoveRange(pedidoProdutosRemover);
            _contexto.Produtos.Remove(produtoRemover);
            _contexto.SaveChanges();
            return true;
        }
    }
}
