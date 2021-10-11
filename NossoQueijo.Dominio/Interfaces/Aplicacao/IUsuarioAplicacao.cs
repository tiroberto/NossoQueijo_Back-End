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
        public Usuario BuscarPorId(int id);
        public IEnumerable<Usuario> ListarPorIdTipoUsuario(int idTipoUsuario);
        public NotificationResult VerificarLogin(string email, string senha);
        public NotificationResult RemoverPorIdTipoUsuario(int idTipoUsuario);
        public NotificationResult RemoverPersonalizado(int id);
    }
}
