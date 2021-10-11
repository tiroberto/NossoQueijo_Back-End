using NossoQueijo.Dominio.Entidades;
using NossoQueijo.Dominio.Interfaces.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NossoQueijo.Repositorio.RepositoriosEF
{
    public class TipoUsuarioRepositorio : RepositorioBase<TipoUsuario> , ITipoUsuarioRepositorio
    {
        private Contexto _contexto;

        public TipoUsuarioRepositorio()
        {
            _contexto = new Contexto();
        }

        public IEnumerable<TipoUsuario> ListarTodos()
        {
            return _contexto.TiposUsuario
                .ToList();

        }

        public TipoUsuario BuscarPorId(int id)
        {
            return _contexto.TiposUsuario
                .First(x => x.idTipoUsuario == id);
        }

        public bool RemoverPersonalizado(int id)
        {
            TipoUsuario tipoUsuarioRemover = _contexto.TiposUsuario.First(x => x.idTipoUsuario == id);
            IEnumerable<Usuario> usuariosAtualizar = _contexto.Usuarios.Where(x => x.TipoUsuario.idTipoUsuario == id).ToList();
            foreach (var item in usuariosAtualizar)
            {
                item.TipoUsuario.idTipoUsuario = 0;
            }
            _contexto.Usuarios
                .UpdateRange(usuariosAtualizar);
            _contexto.Remove(tipoUsuarioRemover);
            _contexto.SaveChanges();
            return true;
        }
    }
}
