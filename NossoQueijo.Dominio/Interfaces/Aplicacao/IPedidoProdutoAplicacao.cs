using NossoQueijo.Comum.NotificationPattern;
using NossoQueijo.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace NossoQueijo.Dominio.Interfaces.Aplicacao
{
    public interface IPedidoProdutoAplicacao
    {
        //public NotificationResult AdicionarEmMassa(IEnumerable<PedidoProduto> pedidoProdutos);
        //public NotificationResult AtualizarEmMassa(IEnumerable<PedidoProduto> pedidoProdutos);
        public IEnumerable<PedidoProduto> ListarTodos();
        public IEnumerable<PedidoProduto> ListarPorIdPedido(int idPedido);
        public NotificationResult Remover(int idPedido, int idProduto);
    }
}
