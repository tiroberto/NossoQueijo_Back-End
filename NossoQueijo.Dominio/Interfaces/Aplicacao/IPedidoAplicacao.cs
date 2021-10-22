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
        public NotificationResult ListarPorIdUsuario(int idUsuario);
        public NotificationResult ListarPorIdStatus(int idStatus);
        public NotificationResult ListarPorIdFormaPagamento(int idFormaPagamento);
        public NotificationResult BuscarPorId(int id);
        public NotificationResult Remover(int id);
    }
}
