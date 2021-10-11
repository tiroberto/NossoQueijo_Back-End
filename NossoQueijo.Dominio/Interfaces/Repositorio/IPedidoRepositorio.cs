using NossoQueijo.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace NossoQueijo.Dominio.Interfaces.Repositorio
{
    public interface IPedidoRepositorio : IRepositorioBase<Pedido>
    {
        public IEnumerable<Pedido> ListarTodos();
        public IEnumerable<Pedido> ListarPorIdUsuario(int idUsuario);
        public IEnumerable<Pedido> ListarPorIdStatus(int idStatus);
        public IEnumerable<Pedido> ListarPorIdFormaPagamento(int idFormaPagamento);
        public Pedido BuscarPorId(int id);
        public bool RemoverPersonalizado(int id);
    }
}
