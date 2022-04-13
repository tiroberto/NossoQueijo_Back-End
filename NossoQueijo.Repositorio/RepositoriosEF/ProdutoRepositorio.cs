using NossoQueijo.Dominio.Entidades;
using NossoQueijo.Dominio.Interfaces.Repositorio;
using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Canducci.Pagination;

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
                   .Include(x => x.FichasProducao)
                   .ThenInclude(x => x.Usuario)
                   .Include(x => x.EstoquePorDatas)
                   .Include(x => x.PedidoProdutos)
                   .AsNoTracking()
                   .ToList();
        }

        public dynamic ListarTodosPaginado(int pagina)
        {
            return _contexto.Produtos
                .AsNoTracking()
                .ToPaginatedRest(pagina, 10);
        }

        public Produto BuscarPorId(int id)
        {
            return _contexto.Produtos
                .Include(x => x.FichasProducao)
                .Include(x => x.EstoquePorDatas)
                .First(x => x.idProduto == id);
        }

        public void RemoverPersonalizado(int id)
        {
            Produto produtoRemover = _contexto.Produtos.First(x => x.idProduto == id);
            IEnumerable<PedidoProduto> pedidoProdutosRemover = _contexto.PedidoProdutos.Where(x => x.Produto.idProduto == id);
            IEnumerable<FichaProducao> fichasProducaoRemover = _contexto.FichasProducao.Where(x => x.Produto.idProduto == id);
            IEnumerable<EstoquePorData> estoquePorDatasRemover = _contexto.EstoquePorDatas.Where(x => x.FichaProducao.EstoquePorData.idProduto == id);

            _contexto.EstoquePorDatas.RemoveRange(estoquePorDatasRemover);
            _contexto.FichasProducao.RemoveRange(fichasProducaoRemover);
            _contexto.PedidoProdutos.RemoveRange(pedidoProdutosRemover);
            _contexto.Produtos.Remove(produtoRemover);
            _contexto.SaveChanges();
        }
    }
}
