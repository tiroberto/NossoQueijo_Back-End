using NossoQueijo.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace NossoQueijo.Dominio.Interfaces.Repositorio
{
    public interface IProdutoRepositorio : IRepositorioBase<Produto>
    {
        public IEnumerable<Produto> ListarTodos();
        public Produto BuscarPorId(int id);
        public void RemoverPersonalizado(int id);
    }
}
