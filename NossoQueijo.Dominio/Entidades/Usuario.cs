using System;
using System.Collections.Generic;
using System.Text;

namespace NossoQueijo.Dominio.Entidades
{
    public class Usuario
    {
        public int idUsuario { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public DateTime DataNascimento { get; set; }
        public IEnumerable<Endereco> Enderecos { get; set; }
        public TipoUsuario TipoUsuario { get; set; }
        public IEnumerable<Pedido> Pedidos { get; set; }
        public IEnumerable<FichaProducao> FichasProducao { get; set; }
    }
}
