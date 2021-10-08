using System;
using System.Collections.Generic;
using System.Text;
using NossoQueijo.Dominio.Entidades;
using NossoQueijo.Dominio.Interfaces.Repositorio;
using NossoQueijo.Comum.NotificationPattern;
using NossoQueijo.Dominio.Interfaces.Aplicacao;

namespace AnBertoCars.Aplicacao
{
    public class StatusAplicacao : IStatusAplicacao
    {
        private readonly IStatusRepositorio _StatusRepositorio;

        public StatusAplicacao(IStatusRepositorio Statusrepositorio)
        {
            _StatusRepositorio = Statusrepositorio;
        }

        public NotificationResult Salvar(Status entidade)
        {
            var notificationResult = new NotificationResult();

            try
            {
                if (notificationResult.IsValid)
                {

                    if (entidade.idStatus == 0)
                    {
                        _StatusRepositorio.Adicionar(entidade);
                        notificationResult.Add("Avaliacao cadastrada com sucesso.");
                    }
                    else
                    {
                        _StatusRepositorio.Atualizar(entidade);
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

        public IEnumerable<Status> ListarTodos()
        {
            return _StatusRepositorio.ListarTodos();
        }

        public string Excluir(Status entidade)
        {
            _StatusRepositorio.Remover(entidade);
            return "Excluido";
        }
    }
}
