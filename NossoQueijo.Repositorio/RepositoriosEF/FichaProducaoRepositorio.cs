using Canducci.Pagination;
using Microsoft.EntityFrameworkCore;
using NossoQueijo.Comum.NotificationPattern;
using NossoQueijo.Dominio.Entidades;
using NossoQueijo.Dominio.Interfaces.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NossoQueijo.Repositorio.RepositoriosEF
{
    public class FichaProducaoRepositorio : RepositorioBase<FichaProducao> , IFichaProducaoRepositorio
    {
        private Contexto _contexto;

        public FichaProducaoRepositorio()
        {
            _contexto = new Contexto();
        }

        public IEnumerable<FichaProducao> ListarTodos()
        {
            return _contexto.FichasProducao
                .Include(x => x.Usuario)
                .ThenInclude(y => y.Enderecos)
                .ThenInclude(y => y.Cidade)
                .ThenInclude(y => y.Estado)
                .Include(x => x.Usuario)
                .ThenInclude(y => y.TipoUsuario)
                .Include(x => x.Produto)
                .ToList();
        }

        public int AdicionarPersonalizado(FichaProducao fichaProducao)
        {
            fichaProducao.Usuario = _contexto.Usuarios
                .Where(x => x.idUsuario == fichaProducao.Usuario.idUsuario)
                .First();
            fichaProducao.Produto = _contexto.Produtos
                .Where(x => x.idProduto == fichaProducao.Produto.idProduto)
                .First();
            fichaProducao.EstoquePorData.Produto = fichaProducao.Produto;
            _contexto.FichasProducao.Add(fichaProducao);

            var produtoAtualizar = _contexto.Produtos
                .First(x => x.idProduto == fichaProducao.Produto.idProduto);
            produtoAtualizar.QntdEstoque += fichaProducao.QntdProduzida;
            _contexto.Produtos.Update(produtoAtualizar);

            _contexto.SaveChanges();

            return fichaProducao.idFichaProducao;
        }

        public void AtualizarPersonalizado(FichaProducao fichaProducao)
        {
            fichaProducao.Usuario = _contexto.Usuarios
                            .Where(x => x.idUsuario == fichaProducao.Usuario.idUsuario)
                            .First();
            fichaProducao.Produto = _contexto.Produtos
                .Where(x => x.idProduto == fichaProducao.Produto.idProduto)
                .First();
            fichaProducao.EstoquePorData.Produto = fichaProducao.Produto;
            _contexto.FichasProducao.Update(fichaProducao);

            var produtoAtualizar = _contexto.Produtos
                .First(x => x.idProduto == fichaProducao.Produto.idProduto);
            produtoAtualizar.QntdEstoque += fichaProducao.QntdProduzida;
            _contexto.Produtos.Update(produtoAtualizar);

            _contexto.SaveChanges();
        }

        public dynamic ListarPorIdUsuarioPaginado(int idUsuario, int pagina)
        {
            return _contexto.FichasProducao
                .Include(x => x.Usuario)
                .Include(x => x.Produto)
                .AsNoTracking()
                .OrderBy(x => x.Data)
                .Where(x => x.Usuario.idUsuario == idUsuario)
                .ToPaginatedRest(pagina, 10);
        }

        public dynamic ListarPorPeriodoPaginado(DateTime inicio, DateTime fim, int pagina)
        {
            return _contexto.FichasProducao
                .Include(x => x.Usuario)
                .Include(x => x.Produto)
                .AsNoTracking()
                .OrderBy(x => x.Data)
                .Where(x => (x.Data >= inicio) && (x.Data <= fim))
                .ToPaginatedRest(pagina, 10);
        }
         
        public FichaProducao BuscarPorId(int id)
        {
            return _contexto.FichasProducao
                .Include(x => x.Usuario)
                .ThenInclude(y => y.Enderecos)
                .ThenInclude(y => y.Cidade)
                .ThenInclude(y => y.Estado)
                .Include(x => x.Produto)
                .First(x => x.idFichaProducao == id);
        }

        public void RemoverPersonalizado(int id)
        {
            FichaProducao fichaProducaoRemover = _contexto.FichasProducao.First(x => x.idFichaProducao == id);
            IEnumerable<EstoquePorData> estoquePorDataRemover = _contexto.EstoquePorDatas.Where(x => x.FichaProducao.idFichaProducao == id).ToList();
            _contexto.EstoquePorDatas.RemoveRange(estoquePorDataRemover);
            _contexto.Remove(fichaProducaoRemover);
            _contexto.SaveChanges();
        }
    }
}
