using NossoQueijo.Comum.NotificationPattern;
using NossoQueijo.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace NossoQueijo.Dominio.Interfaces.Aplicacao
{
    public interface IUsuarioAplicacao
    {
        public NotificationResult Salvar(Usuario entidade);

        public IEnumerable<Usuario> ListarTodos();

        public string Excluir(Usuario entidade);
    }
}
