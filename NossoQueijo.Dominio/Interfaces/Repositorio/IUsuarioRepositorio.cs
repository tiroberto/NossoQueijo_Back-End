using NossoQueijo.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace NossoQueijo.Dominio.Interfaces.Repositorio
{
    public interface IUsuarioRepositorio : IRepositorioBase<Usuario>
    {
        public IEnumerable<Usuario> ListarTodos();
        public void AdicionarPersonalizado(Usuario usuario);
        public void AtualizarPersonalizado(Usuario usuario);
        public Usuario BuscarPorId(int id);
        public IEnumerable<Usuario> ListarPorIdTipoUsuario(int idTipoUsuario);
        public Usuario VerificarLogin(string email, string senha);
        public void RemoverPorIdTipoUsuario(int idTipoUsuario);
        public void RemoverPersonalizado(int id);
    }
}
