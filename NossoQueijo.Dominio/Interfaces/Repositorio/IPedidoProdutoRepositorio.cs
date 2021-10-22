using NossoQueijo.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace NossoQueijo.Dominio.Interfaces.Repositorio
{
    public interface IPedidoProdutoRepositorio : IRepositorioBase<PedidoProduto>
    {
        public void AdicionarEmMassa(IEnumerable<PedidoProduto> pedidoProdutos);
        public void AtualizarEmMassa(IEnumerable<PedidoProduto> pedidoProdutos);
        public IEnumerable<PedidoProduto> ListarTodos();
        public IEnumerable<PedidoProduto> ListarPorIdPedido(int idPedido);
    }
}
