using NossoQueijo.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace NossoQueijo.Dominio.Interfaces.Repositorio
{
    public interface IStatusRepositorio : IRepositorioBase<Status>
    {
        public IEnumerable<Status> ListarTodos();
        public Status BuscarPorId(int id);
        public bool RemoverPersonalizado(int id);
    }
}
