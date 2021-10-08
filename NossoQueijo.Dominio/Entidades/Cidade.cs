using System.Collections.Generic;

namespace NossoQueijo.Dominio.Entidades
{
    public class Cidade
    {
        public int idCidade { get; set; }
        public string Nome { get; set; }
        public Estado Estado { get; set; }
        public IEnumerable<Endereco> Enderecos { get; set; }
    }
}