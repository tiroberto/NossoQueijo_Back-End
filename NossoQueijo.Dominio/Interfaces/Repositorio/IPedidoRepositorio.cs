using NossoQueijo.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace NossoQueijo.Dominio.Interfaces.Repositorio
{
    public interface IPedidoRepositorio : IRepositorioBase<Pedido>
    {
        public int AdicionarPersonalizado(Pedido pedido);
        public void AtualizarPersonalizado(Pedido pedido);
        public Pedido UltimoAdicionado();
        public dynamic ListarPorPeriodoPaginado(DateTime inicio, DateTime fim, int pagina);
        public IEnumerable<Pedido> ListarTodos();
        public dynamic ListarTodosPaginado(int pagina);
        public dynamic ListarPorIdUsuarioPaginado(int idUsuario, int pagina);
        public dynamic ListarPorIdStatusPaginado(int idStatus, int pagina);
        public dynamic ListarPorIdFormaPagamentoPaginado(int idFormaPagamento, int pagina);
        public Pedido BuscarPorId(int id);
        public void RemoverPersonalizado(int id);
    }
}
