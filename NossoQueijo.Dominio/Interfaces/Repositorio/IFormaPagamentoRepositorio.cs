using NossoQueijo.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace NossoQueijo.Dominio.Interfaces.Repositorio
{
    public interface IFormaPagamentoRepositorio : IRepositorioBase<FormaPagamento>
    {
        public IEnumerable<FormaPagamento> ListarTodos();
        public FormaPagamento BuscarPorId(int id);
        public bool RemoverPersonalizado(int id);
    }
}
