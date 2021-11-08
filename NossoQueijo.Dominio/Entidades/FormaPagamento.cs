using System;
using System.Collections.Generic;
using System.Text;

namespace NossoQueijo.Dominio.Entidades
{
    public class FormaPagamento
    {
        public int idFormaPagamento { get; set; }
        public string Descricao { get; set; }
        public string Imagem { get; set; }
        public IEnumerable<Pedido> Pedidos { get; set; }
    }
}
