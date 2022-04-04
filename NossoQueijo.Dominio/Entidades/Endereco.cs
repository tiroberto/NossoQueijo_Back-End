using System.Collections.Generic;

namespace NossoQueijo.Dominio.Entidades
{
    public class Endereco
    {
        public int idEndereco { get; set; }
        public string Rua { get; set; }
        public int Numero { get; set; }
        public string Bairro { get; set; }
        public string CEP { get; set; }
        public string Complemento { get; set; }
        public Cidade Cidade { get; set; }
        public Usuario Usuario { get; set; }
        public IEnumerable<Pedido> Pedidos { get; set; }
    }
}