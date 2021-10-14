using Microsoft.EntityFrameworkCore;
using NossoQueijo.Comum.NotificationPattern;
using NossoQueijo.Dominio.Entidades;
using NossoQueijo.Dominio.Interfaces.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NossoQueijo.Repositorio.RepositoriosEF
{
    public class CidadeRepositorio : RepositorioBase<Cidade> , ICidadeRepositorio
    {
        private Contexto _contexto;

        public CidadeRepositorio()
        {
            _contexto = new Contexto();
        }

        public void AdicionarPersonalizado(Cidade cidade)
        {
            cidade.Estado = _contexto.Estados
                .ToList()
                .Where(x => x.idEstado == cidade.Estado.idEstado)
                .FirstOrDefault();
            _contexto.Cidades.Add(cidade);
            _contexto.SaveChanges();
        }

        public void AtualizarPersonalizado(Cidade cidade)
        {
            cidade.Estado = _contexto.Estados
                .ToList()
                .Where(x => x.idEstado == cidade.Estado.idEstado)
                .FirstOrDefault();
            _contexto.Cidades.Update(cidade);
            _contexto.SaveChanges();
        }

        public IEnumerable<Cidade> ListarTodos()
        {
            return _contexto.Cidades
                .Include(x => x.Estado)
                .ToList();
        }

        public Cidade BuscarPorId(int id)
        {
            return _contexto.Cidades
                .Include(x => x.Estado)
                .First(x => x.idCidade == id);
        }

        public IEnumerable<Cidade> ListarPorIdEstado(int idEstado)
        {
            return _contexto.Cidades
                .Where(x => x.Estado.idEstado == idEstado)
                .ToList();
        }
    }
}
