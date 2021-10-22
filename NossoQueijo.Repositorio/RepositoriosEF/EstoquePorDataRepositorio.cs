using Microsoft.EntityFrameworkCore;
using NossoQueijo.Dominio.Entidades;
using NossoQueijo.Dominio.Interfaces.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NossoQueijo.Repositorio.RepositoriosEF
{
    public class EstoquePorDataRepositorio : RepositorioBase<EstoquePorData>, IEstoquePorDataRepositorio
    {
        private Contexto _contexto;

        public EstoquePorDataRepositorio()
        {
            _contexto = new Contexto();
        }

        public IEnumerable<EstoquePorData> ListarTodos()
        {
            return _contexto.EstoquePorDatas
                .Include(x => x.FichaProducao)
                .ThenInclude(y => y.Usuario)
                .ThenInclude(y => y.Enderecos)
                .ThenInclude(y => y.Cidade)
                .ThenInclude(y => y.Estado)
                .Include(x => x.Produto)
                .ToList();
        }

        public EstoquePorData BuscarPorIdFichaProducao(int idFichaProducao)
        {
            return _contexto.EstoquePorDatas
                .Include(x => x.FichaProducao)
                .ThenInclude(y => y.Usuario)
                .ThenInclude(y => y.Enderecos)
                .ThenInclude(y => y.Cidade)
                .ThenInclude(y => y.Estado)
                .Include(x => x.Produto)
                .First(x => x.idFichaProducao == idFichaProducao);
        }

        public IEnumerable<EstoquePorData> ListarPorPeriodo(DateTime inicio, DateTime fim)
        {
            return _contexto.EstoquePorDatas
                .Include(x => x.FichaProducao)
                .ThenInclude(y => y.Usuario)
                .ThenInclude(y => y.Enderecos)
                .ThenInclude(y => y.Cidade)
                .ThenInclude(y => y.Estado)
                .Include(x => x.Produto)
                .Where(x => (x.FichaProducao.Data >= inicio) && (x.FichaProducao.Data <= fim))
                .ToList();
        }

        public void RemoverPorIdFichaProducao(int idFichaProducao)
        {
            EstoquePorData estoquePorDataRemover = _contexto.EstoquePorDatas
                .First(x => x.idFichaProducao == idFichaProducao);
            _contexto.EstoquePorDatas.Remove(estoquePorDataRemover);
            SaveChanges();
        }

        public void RemoverPorIdProduto(int idProduto)
        {
            IEnumerable<EstoquePorData> estoquePorDataRemover = _contexto.EstoquePorDatas
                .Where(x => x.Produto.idProduto == idProduto)
                .ToList();
            _contexto.EstoquePorDatas.RemoveRange(estoquePorDataRemover);
            SaveChanges();
        }
        
        public IEnumerable<EstoquePorData> ListarPorIdProduto(int idProduto)
        {
            return _contexto.EstoquePorDatas
                .Include(x => x.FichaProducao)
                .ThenInclude(y => y.Usuario)
                .ThenInclude(y => y.Enderecos)
                .ThenInclude(y => y.Cidade)
                .ThenInclude(y => y.Estado)
                .Include(x => x.Produto)
                .Where(x => x.Produto.idProduto == idProduto)
                .ToList();
        }
    }
}
