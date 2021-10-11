using NossoQueijo.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace NossoQueijo.Dominio.Interfaces.Repositorio
{
    public interface ITipoUsuarioRepositorio : IRepositorioBase<TipoUsuario>
    {
        public IEnumerable<TipoUsuario> ListarTodos();
        public TipoUsuario BuscarPorId(int id);
        public bool RemoverPersonalizado(int id);
    }
}
