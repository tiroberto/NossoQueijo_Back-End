using Microsoft.EntityFrameworkCore;
using NossoQueijo.Dominio.Entidades;
using NossoQueijo.Dominio.Interfaces.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NossoQueijo.Repositorio.RepositoriosEF
{
    public class UsuarioRepositorio : RepositorioBase<Usuario> , IUsuarioRepositorio
    {
        private Contexto _contexto;

        public UsuarioRepositorio()
        {
            _contexto = new Contexto();
        }

        public IEnumerable<Usuario> ListarTodos()
        {
            return _contexto.Usuarios
                .Include(x => x.TipoUsuario)
                .Include(x => x.Endereco)
                .ThenInclude(y => y.Cidade)
                .ThenInclude(y => y.Estado)
                .ToList();
        }

        public Usuario BuscarPorId(int id)
        {
            return _contexto.Usuarios
                .First(x => x.idUsuario == id);
        }

        public IEnumerable<Usuario> ListarPorIdTipoUsuario(int idTipoUsuario)
        {
            return _contexto.Usuarios
                .Include(x => x.TipoUsuario)
                .Include(x => x.Endereco)
                .ThenInclude(y => y.Cidade)
                .ThenInclude(y => y.Estado)
                .Where(x => x.TipoUsuario.idTipoUsuario == idTipoUsuario)
                .ToList();
        }

        public Usuario VerificarLogin(string email, string senha)
        {
            return _contexto.Usuarios
                .First(x => (x.Email == email) && (x.Senha == senha));
        }

        public bool RemoverPorIdTipoUsuario(int idTipoUsuario)
        {
            IEnumerable<Usuario> usuariosRemover = _contexto.Usuarios.Where(x => x.TipoUsuario.idTipoUsuario == idTipoUsuario);
            _contexto.RemoveRange(usuariosRemover);
            _contexto.SaveChanges();
            return true;
        }

        public bool RemoverPersonalizado(int id)
        {
            Usuario usuariosRemover = _contexto.Usuarios.First(x => x.idUsuario == id);
            //Remove pedidos do usuário
            IEnumerable<Pedido> pedidosRemover = _contexto.Pedidos.Where(x => x.Usuario.idUsuario == id).ToList();
            _contexto.Pedidos.RemoveRange(pedidosRemover);
            //Remove endereço do usuário
            Endereco enderecoRemover = _contexto.Enderecos.First(x => x.Usuario.idUsuario == id);
            _contexto.Enderecos.Remove(enderecoRemover);
            //Remove fichas de produção do usuário
            IEnumerable<FichaProducao> fichasProducaoRemover = _contexto.FichasProducao.Where(x => x.Usuario.idUsuario == id).ToList();
            _contexto.FichasProducao.RemoveRange(fichasProducaoRemover);
            //Remove o usuário
            _contexto.Remove(usuariosRemover);
            _contexto.SaveChanges();
            return true;
        }
    }
}
