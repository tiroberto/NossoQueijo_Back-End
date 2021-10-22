using System;
using System.Collections.Generic;
using System.Text;
using NossoQueijo.Dominio.Entidades;
using NossoQueijo.Dominio.Interfaces.Repositorio;
using NossoQueijo.Comum.NotificationPattern;
using NossoQueijo.Dominio.Interfaces.Aplicacao;
using NossoQueijo.Comum.Util;
using System.Text.RegularExpressions;

namespace NossoQueijo.Aplicacao
{
    public class UsuarioAplicacao : IUsuarioAplicacao
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public UsuarioAplicacao(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
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
                        _usuarioRepositorio.AdicionarPersonalizado(entidade);
                        notificationResult.Add("Usuário cadastrado com sucesso.");
                    }
                    else if(ValidaCPF.Validar(entidade.CPF))
                    {
                        _usuarioRepositorio.AtualizarPersonalizado(entidade);
                        notificationResult.Add("Usuário atualizado com sucesso.");
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

        public NotificationResult VerificarLogin(string email, string senha)
        {
            var notificationResult = new NotificationResult();
            Regex rg = new Regex(@"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$");
            try
            {
                if ((rg.IsMatch(email)) && (senha.Length >= 8))
                {
                    notificationResult.Result = _usuarioRepositorio.VerificarLogin(email, senha);
                    notificationResult.Add("Usuário verificado com sucesso!");
                }
                return notificationResult;
            }
            catch (Exception ex)
            {
                return notificationResult.Add(new NotificationError(ex.Message));
            }
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
