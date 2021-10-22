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
                .Include(x => x.Enderecos)
                .ThenInclude(x => x.Cidade)
                .ThenInclude(x => x.Estado)
                .Include(x => x.FichasProducao)
                .ToList();
        }

        public void AdicionarPersonalizado(Usuario usuario)
        {
            usuario.TipoUsuario = _contexto.TiposUsuario
                .First(x => x.idTipoUsuario == usuario.TipoUsuario.idTipoUsuario);
            _contexto.Usuarios.Add(usuario);
            _contexto.SaveChanges();
        }

        public void AtualizarPersonalizado(Usuario usuario)
        {
            usuario.TipoUsuario = _contexto.TiposUsuario
                .First(x => x.idTipoUsuario == usuario.TipoUsuario.idTipoUsuario);
            _contexto.Usuarios.Update(usuario);
            _contexto.SaveChanges();
        }

        public Usuario BuscarPorId(int id)
        {
            return _contexto.Usuarios
                .Include(x => x.TipoUsuario)
                .First(x => x.idUsuario == id);
        }

        public IEnumerable<Usuario> ListarPorIdTipoUsuario(int idTipoUsuario)
        {
            return _contexto.Usuarios
                .Include(x => x.TipoUsuario)
                .Include(x => x.Enderecos)
                .ThenInclude(x => x.Cidade)
                .ThenInclude(x => x.Estado)
                .Where(x => x.TipoUsuario.idTipoUsuario == idTipoUsuario)
                .ToList();
        }

        public Usuario VerificarLogin(string email, string senha)
        {
            return _contexto.Usuarios
                .First(x => (x.Email == email) && (x.Senha == senha));
        }

        public void RemoverPorIdTipoUsuario(int idTipoUsuario)
        {
            IEnumerable<Usuario> usuariosRemover = _contexto.Usuarios.Where(x => x.TipoUsuario.idTipoUsuario == idTipoUsuario);

            //Remove pedidos do usuário
            IEnumerable<Pedido> pedidosRemover = _contexto.Pedidos.Where(x => x.Usuario.TipoUsuario.idTipoUsuario == idTipoUsuario).ToList();
            _contexto.Pedidos.RemoveRange(pedidosRemover);
            
            //Remove endereço do usuário
            IEnumerable<Endereco> enderecosRemover = _contexto.Enderecos.Where(x => x.Usuario.TipoUsuario.idTipoUsuario == idTipoUsuario).ToList();
            _contexto.Enderecos.RemoveRange(enderecosRemover);

            //Remove fichas de produção do usuário
            IEnumerable<FichaProducao> fichasProducaoRemover = _contexto.FichasProducao.Where(x => x.Usuario.TipoUsuario.idTipoUsuario == idTipoUsuario).ToList();
            if (fichasProducaoRemover.Count() > 0)
                _contexto.FichasProducao.RemoveRange(fichasProducaoRemover);

            _contexto.RemoveRange(usuariosRemover);
            _contexto.SaveChanges();
        }

        public void RemoverPersonalizado(int id)
        {
            Usuario usuarioRemover = _contexto.Usuarios.First(x => x.idUsuario == id);
            
            //Remove pedidos do usuário
            IEnumerable<Pedido> pedidosRemover = _contexto.Pedidos.Where(x => x.Usuario.idUsuario == id).ToList();
            _contexto.Pedidos.RemoveRange(pedidosRemover);
            
            //Remove endereço do usuário
            IEnumerable<Endereco> enderecosRemover = _contexto.Enderecos.Where(x => x.Usuario.idUsuario == id).ToList();
            _contexto.Enderecos.RemoveRange(enderecosRemover);
            
            //Remove fichas de produção do usuário
            IEnumerable<FichaProducao> fichasProducaoRemover = _contexto.FichasProducao.Where(x => x.Usuario.idUsuario == id).ToList();
            if(fichasProducaoRemover.Count() > 0)
                _contexto.FichasProducao.RemoveRange(fichasProducaoRemover);
            
            //Remove o usuário
            _contexto.Remove(usuarioRemover);
            _contexto.SaveChanges();
        }
    }
}
