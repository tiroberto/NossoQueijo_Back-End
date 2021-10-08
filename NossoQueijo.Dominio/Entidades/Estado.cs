using System.Collections.Generic;

namespace NossoQueijo.Dominio.Entidades
{
    public class Estado
    {
        public int idEstado { get; set; }
        public string Nome { get; set; }
        public IEnumerable<Cidade> Cidades { get; set; }
    }
}