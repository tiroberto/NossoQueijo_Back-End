using NossoQueijo.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace NossoQueijo.Dominio.Interfaces.Repositorio
{
    public interface IEstadoRepositorio : IRepositorioBase<Estado>
    {
        public IEnumerable<Estado> ListarTodos();
        public Estado BuscarPorId(int id);
    }
}
