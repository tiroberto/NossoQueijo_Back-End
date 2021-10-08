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

        public string Excluir(Pedido entidade);
    }
}
