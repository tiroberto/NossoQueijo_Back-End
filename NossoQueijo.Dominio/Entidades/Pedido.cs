using System;
using System.Collections.Generic;

namespace NossoQueijo.Dominio.Entidades
{
    public class Pedido
    {
        public int idPedido { get; set; }
        public Usuario Usuario { get; set; }
        public decimal ValorFrete { get; set; }
        public DateTime Data { get; set; }
        public Endereco EnderecoEntrega { get; set; }
        public FormaPagamento FormaPagamento { get; set; }
        public Status Status { get; set; }
        public IEnumerable<PedidoProduto> PedidoProdutos { get; set; }
    }
}