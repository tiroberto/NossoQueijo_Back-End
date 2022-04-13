using NossoQueijo.Comum.NotificationPattern;
using NossoQueijo.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace NossoQueijo.Dominio.Interfaces.Aplicacao
{
    public interface IPedidoAplicacao
    {
        public NotificationResult Salvar(Pedido entidade);
        public IEnumerable<Pedido> ListarTodos();
        public dynamic ListarTodosPaginado(int pagina);
        public NotificationResult ListarPorPeriodoPaginado(DateTime inicio, DateTime fim, int pagina);
        public NotificationResult ListarPorIdUsuarioPaginado(int idUsuario, int pagina);
        public NotificationResult ListarPorIdStatusPaginado(int idStatus, int pagina);
        public NotificationResult ListarPorIdFormaPagamentoPaginado(int idFormaPagamento, int pagina);
        public NotificationResult BuscarPorId(int id);
        public NotificationResult Remover(int id);
    }
}
