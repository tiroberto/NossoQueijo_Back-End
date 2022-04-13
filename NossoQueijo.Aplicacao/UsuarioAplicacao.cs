using System;
using System.Collections.Generic;
using System.Text;
using NossoQueijo.Dominio.Entidades;
using NossoQueijo.Dominio.Interfaces.Repositorio;
using NossoQueijo.Comum.NotificationPattern;
using NossoQueijo.Dominio.Interfaces.Aplicacao;
using NossoQueijo.Comum.Util;
using Microsoft.AspNetCore.Authorization;
using System.Text.RegularExpressions;

namespace NossoQueijo.Aplicacao
{
    public class UsuarioAplicacao : IUsuarioAplicacao
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly IPedidoRepositorio _pedidoRepositorio;

        public UsuarioAplicacao(IUsuarioRepositorio usuarioRepositorio, IPedidoRepositorio pedidoRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _pedidoRepositorio = pedidoRepositorio;
        }

        public NotificationResult Salvar(Usuario entidade)
        {
            var notificationResult = new NotificationResult();
            try
            {
                if (notificationResult.IsValid)
                {
                    if ((entidade.idUsuario == 0) && (ValidaCPF.Validar(entidade.CPF)))
                    {
                        var verificaLoginExistencia = _usuarioRepositorio.VerificarLogin(entidade.Email, entidade.Senha);
                        if (verificaLoginExistencia != null)
                        {
                            notificationResult.Result = verificaLoginExistencia;
                            notificationResult.Add("Usuário já possui cadastro.");
                            return notificationResult;
                        }
                        else
                        {
                            entidade.idUsuario = _usuarioRepositorio.AdicionarPersonalizado(entidade);
                            if (entidade.idUsuario > 0)
                            {
                                notificationResult.Add("Usuário cadastrado com sucesso.");
                                notificationResult.Result = entidade;
                                return notificationResult;
                            }
                        }
                    }
                    else if(ValidaCPF.Validar(entidade.CPF))
                    {
                        _usuarioRepositorio.AtualizarPersonalizado(entidade);
                        notificationResult.Add("Usuário atualizado com sucesso.");
                    }
                    else
                    {
                        notificationResult.Add("CPF inválido");
                    }

                }

                notificationResult.Result = entidade;

                return notificationResult;
            }
            catch (Exception ex)
            {
                return notificationResult.Add(new NotificationError(ex.Message));
            }
        }

        public IEnumerable<Usuario> ListarTodos()
        {
            return _usuarioRepositorio.ListarTodos();
        }

        public NotificationResult BuscarPorId(int id)
        {
            var notificationResult = new NotificationResult();
            try
            {
                if (notificationResult.IsValid)
                {
                    notificationResult.Result = _usuarioRepositorio.BuscarPorId(id);
                    notificationResult.Add("Encontrado com sucesso!");
                }
                return notificationResult;
            }
            catch (Exception ex)
            {
                return notificationResult.Add(new NotificationError(ex.Message));
            }
        }

        public IEnumerable<Usuario> ListarPorIdTipoUsuario(int idTipoUsuario)
        {
            return _usuarioRepositorio.ListarPorIdTipoUsuario(idTipoUsuario);
        }

        public dynamic VerificarLogin(string email, string senha)
        {
            Regex rg = new Regex(@"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$");
            Usuario usuario = new Usuario();
            if ((rg.IsMatch(email)) && (senha.Length >= 8))
                usuario = _usuarioRepositorio.VerificarLogin(email, senha);


            if (usuario == null)
                return new { usuario = "", token = "", message = "Usuário ou senha inválidos.", logado = false };

            var token = Token.GenerateToken(usuario);
            usuario.Senha = "";
            var pedidos = _pedidoRepositorio.ListarPorIdUsuarioPaginado(usuario.idUsuario, 1);            

            return new { usuario = usuario, pedidos = pedidos, enderecos = usuario.Enderecos, token = token, message = "Login efetuado com sucesso.", logado = true};
        }

        public NotificationResult RemoverPorIdTipoUsuario(int idTipoUsuario)
        {
            var notificationResult = new NotificationResult();
            try
            {
                if (notificationResult.IsValid)
                {
                    if (idTipoUsuario > 0)
                    {
                        _usuarioRepositorio.RemoverPorIdTipoUsuario(idTipoUsuario);
                        notificationResult.Add("Usuários removidos com sucesso!");
                    }
                }
                return notificationResult;
            }
            catch (Exception ex)
            {
                notificationResult.Add(new NotificationError(ex.Message));
                return notificationResult;
            }
        }

        public NotificationResult Remover(int id)
        {
            var notificationResult = new NotificationResult();
            try
            {
                if (notificationResult.IsValid)
                {
                    _usuarioRepositorio.RemoverPersonalizado(id);
                    notificationResult.Add("Usuário removido com sucesso!");
                }
                return notificationResult;
            }
            catch (Exception ex)
            {
                return notificationResult.Add(new NotificationError(ex.Message));
            }
        }
    }
}
