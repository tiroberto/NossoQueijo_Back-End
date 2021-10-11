using NossoQueijo.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace NossoQueijo.Dominio.Interfaces.Repositorio
{
    public interface ICidadeRepositorio : IRepositorioBase<Cidade>
    {
        public IEnumerable<Cidade> ListarTodos();
        public Cidade BuscarPorId(int id);
        public IEnumerable<Cidade> ListarPorIdEstado(int idEstado);
    }
}
