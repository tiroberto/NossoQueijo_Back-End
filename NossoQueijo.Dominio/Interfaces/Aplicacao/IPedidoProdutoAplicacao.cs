using NossoQueijo.Comum.NotificationPattern;
using NossoQueijo.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace NossoQueijo.Dominio.Interfaces.Aplicacao
{
    public interface IPedidoProdutoAplicacao
    {
        public NotificationResult Salvar(PedidoProduto entidade);
        public IEnumerable<PedidoProduto> ListarTodos();
        public IEnumerable<PedidoProduto> ListarPorIdPedido(int idPedido);
        public string Excluir(PedidoProduto entidade);
    }
}
