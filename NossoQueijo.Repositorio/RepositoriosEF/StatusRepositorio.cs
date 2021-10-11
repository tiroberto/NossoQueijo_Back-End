using NossoQueijo.Dominio.Entidades;
using NossoQueijo.Dominio.Interfaces.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace NossoQueijo.Repositorio.RepositoriosEF
{
    public class  StatusRepositorio : RepositorioBase<Status> , IStatusRepositorio
    {
        private Contexto _contexto;

        public StatusRepositorio()
        {
            _contexto = new Contexto();
        }

        public IEnumerable<Status> ListarTodos()
        {
            return _contexto.Status
                .ToList();

        }

        public Status BuscarPorId(int id)
        {
            return _contexto.Status
                .First(x => x.idStatus == id);
        }

        public bool RemoverPersonalizado(int id)
        {
            Status statusRemover = _contexto.Status.First(x => x.idStatus == id);
            IEnumerable<Pedido> pedidosAtualizar = _contexto.Pedidos.Where(x => x.Status.idStatus == id).ToList();
            foreach (var item in pedidosAtualizar)
            {
                item.Status.idStatus = 0;
            }
            _contexto.Pedidos
                .UpdateRange(pedidosAtualizar);
            _contexto.Remove(statusRemover);
            _contexto.SaveChanges();
            return true;
        }
    }
}
