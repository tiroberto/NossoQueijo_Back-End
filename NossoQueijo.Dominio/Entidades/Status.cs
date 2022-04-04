using System.Collections.Generic;

namespace NossoQueijo.Dominio.Entidades
{
    public class Status
    {
        public int idStatus { get; set; }
        public string Descricao { get; set; }
        public string Imagem { get; set; }
        public IEnumerable<Pedido> Pedidos { get; set; }
    }
}