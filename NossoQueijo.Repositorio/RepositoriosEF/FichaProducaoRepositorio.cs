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
                .ThenInclude(y => y.Endereco)
                .ThenInclude(y => y.Cidade)
                .ThenInclude(y => y.Estado)
                .Include(x => x.Usuario)
                .ThenInclude(y => y.TipoUsuario)
                .ToList();
        }

        public IEnumerable<FichaProducao> ListarPorIdUsuario(int idUsuario)
        {
            return _contexto.FichasProducao
                .Where(x => x.Usuario.idUsuario == idUsuario);
        }

        public IEnumerable<FichaProducao> ListarPorPeriodo(DateTime inicio, DateTime fim)
        {
            return _contexto.FichasProducao
                .Where(x => (x.Data >= inicio) && (x.Data <= fim));
        }
         
        public FichaProducao BuscarPorId(int id)
        {
            return _contexto.FichasProducao
                .Include(x => x.Usuario)
                .ThenInclude(y => y.Endereco)
                .Include(x => x.Usuario)
                .ThenInclude(y => y.TipoUsuario)
                .First(x => x.idFichaProducao == id);
        }

        public bool RemoverPersonalizado(int id)
        {
            FichaProducao fichaProducaoRemover = _contexto.FichasProducao.First(x => x.idFichaProducao == id);
            IEnumerable<EstoquePorData> estoquePorDataRemover = _contexto.EstoquePorDatas.Where(x => x.FichaProducao.idFichaProducao == id).ToList();
            _contexto.EstoquePorDatas.RemoveRange(estoquePorDataRemover);
            _contexto.Remove(fichaProducaoRemover);
            _contexto.SaveChanges();
            return true;
        }
    }
}
