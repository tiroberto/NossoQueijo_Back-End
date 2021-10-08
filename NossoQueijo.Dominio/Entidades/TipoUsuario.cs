using System.Collections.Generic;

namespace NossoQueijo.Dominio.Entidades
{
    public class TipoUsuario
    {
        public int idTipoUsuario { get; set; }
        public string Descricao { get; set; }
        public IEnumerable<Usuario> Usuarios { get; set; }
    }
}