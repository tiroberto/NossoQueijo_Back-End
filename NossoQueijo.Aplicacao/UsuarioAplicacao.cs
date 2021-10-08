using System;
using System.Collections.Generic;
using System.Text;
using NossoQueijo.Dominio.Entidades;
using NossoQueijo.Dominio.Interfaces.Repositorio;
using NossoQueijo.Comum.NotificationPattern;
using NossoQueijo.Dominio.Interfaces.Aplicacao;

namespace AnBertoCars.Aplicacao
{
    public class UsuarioAplicacao : IUsuarioAplicacao
    {
        private readonly IUsuarioRepositorio _UsuarioRepositorio;

        public UsuarioAplicacao(IUsuarioRepositorio Usuariorepositorio)
        {
            _UsuarioRepositorio = Usuariorepositorio;
        }

        public NotificationResult Salvar(Usuario entidade)
        {
            var notificationResult = new NotificationResult();

            try
            {
                if (notificationResult.IsValid)
                {

                    if (entidade.idUsuario == 0)
                    {
                        _UsuarioRepositorio.Adicionar(entidade);
                        notificationResult.Add("Avaliacao cadastrada com sucesso.");
                    }
                    else
                    {
                        _UsuarioRepositorio.Atualizar(entidade);
                        notificationResult.Add("Avaliacao atualizada com sucesso.");
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
            return _UsuarioRepositorio.ListarTodos();
        }

        public string Excluir(Usuario entidade)
        {
            _UsuarioRepositorio.Remover(entidade);
            return "Excluido";
        }
    }
}
