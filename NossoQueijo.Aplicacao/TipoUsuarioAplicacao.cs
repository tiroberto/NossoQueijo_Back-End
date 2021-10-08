using System;
using System.Collections.Generic;
using System.Text;
using NossoQueijo.Dominio.Entidades;
using NossoQueijo.Dominio.Interfaces.Repositorio;
using NossoQueijo.Comum.NotificationPattern;
using NossoQueijo.Dominio.Interfaces.Aplicacao;

namespace AnBertoCars.Aplicacao
{
    public class TipoUsuarioAplicacao : ITipoUsuarioAplicacao
    {
        private readonly ITipoUsuarioRepositorio _TipoUsuarioRepositorio;

        public TipoUsuarioAplicacao(ITipoUsuarioRepositorio TipoUsuariorepositorio)
        {
            _TipoUsuarioRepositorio = TipoUsuariorepositorio;
        }

        public NotificationResult Salvar(TipoUsuario entidade)
        {
            var notificationResult = new NotificationResult();

            try
            {
                if (notificationResult.IsValid)
                {

                    if (entidade.idTipoUsuario == 0)
                    {
                        _TipoUsuarioRepositorio.Adicionar(entidade);
                        notificationResult.Add("Avaliacao cadastrada com sucesso.");
                    }
                    else
                    {
                        _TipoUsuarioRepositorio.Atualizar(entidade);
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

        public IEnumerable<TipoUsuario> ListarTodos()
        {
            return _TipoUsuarioRepositorio.ListarTodos();
        }

        public string Excluir(TipoUsuario entidade)
        {
            _TipoUsuarioRepositorio.Remover(entidade);
            return "Excluido";
        }
    }
}
