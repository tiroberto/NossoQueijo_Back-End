using NossoQueijo.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace NossoQueijo.Dominio.Interfaces.Repositorio
{
    public interface IEstoquePorDataRepositorio : IRepositorioBase<EstoquePorData>
    {
        public IEnumerable<EstoquePorData> ListarTodos();
        public EstoquePorData BuscarPorId(int id);
        public IEnumerable<EstoquePorData> ListarPorPeriodo(DateTime inicio, DateTime fim);
        public IEnumerable<EstoquePorData> ListarPorIdProduto(int idProduto);
    }
}
