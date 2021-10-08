using System;
using System.Collections.Generic;
using System.Text;

namespace NossoQueijo.Dominio.Entidades
{
    public class PedidoProduto
    {
        public int idProduto { get; set; }
        public Produto Produto { get; set; }
        public int idPedido { get; set; }
        public Pedido Pedido { get; set; }
        public int Quantidade { get; set; }
    }
}
