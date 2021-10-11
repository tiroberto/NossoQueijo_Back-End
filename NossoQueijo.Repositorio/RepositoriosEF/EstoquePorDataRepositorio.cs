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
                .ThenInclude(y => y.Endereco)
                .ThenInclude(y => y.Cidade)
                .ThenInclude(y => y.Estado)
                .Include(x => x.Produto)
                .ToList();
        }

        public EstoquePorData BuscarPorId(int id)
        {
            return _contexto.EstoquePorDatas
                .Include(x => x.FichaProducao)
                .ThenInclude(y => y.Usuario)
                .Include(x => x.Produto)
                .First(x => x.idEstoquePorData == id);
        }

        public IEnumerable<EstoquePorData> ListarPorPeriodo(DateTime inicio, DateTime fim)
        {
            return _contexto.EstoquePorDatas
                .Include(x => x.FichaProducao)
                .ThenInclude(y => y.Usuario)
                .Include(x => x.Produto)
                .Where(x => (x.FichaProducao.Data >= inicio) && (x.FichaProducao.Data <= fim))
                .ToList();
        }
        
        public IEnumerable<EstoquePorData> ListarPorIdProduto(int idProduto)
        {
            return _contexto.EstoquePorDatas
                .Include(x => x.FichaProducao)
                .ThenInclude(y => y.Usuario)
                .Include(x => x.Produto)
                .Where(x => x.Produto.idProduto == idProduto)
                .ToList();
        }
    }
}
