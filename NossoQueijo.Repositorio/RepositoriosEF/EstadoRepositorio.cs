using NossoQueijo.Dominio.Entidades;
using NossoQueijo.Dominio.Interfaces.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NossoQueijo.Repositorio.RepositoriosEF
{
    public class EstadoRepositorio : RepositorioBase<Estado> , IEstadoRepositorio
    {
        private Contexto _contexto;

        public EstadoRepositorio()
        {
            _contexto = new Contexto();
        }

        public IEnumerable<Estado> ListarTodos()
        {
            return _contexto.Estados
                .ToList();
        }

        public Estado BuscarPorId(int id)
        {
            return _contexto.Estados
                .First(x => x.idEstado == id);
        }
    }
}
