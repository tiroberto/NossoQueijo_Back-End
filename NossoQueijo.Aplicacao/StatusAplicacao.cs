using System;
using System.Collections.Generic;
using System.Text;
using NossoQueijo.Dominio.Entidades;
using NossoQueijo.Dominio.Interfaces.Repositorio;
using NossoQueijo.Comum.NotificationPattern;
using NossoQueijo.Dominio.Interfaces.Aplicacao;

namespace NossoQueijo.Aplicacao
{
    public class StatusAplicacao : IStatusAplicacao
    {
        private readonly IStatusRepositorio _statusRepositorio;

        public StatusAplicacao(IStatusRepositorio statusRepositorio)
        {
            _statusRepositorio = statusRepositorio;
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
                        _statusRepositorio.Adicionar(entidade);
                        notificationResult.Add("Status cadastrado com sucesso.");
                    }
                    else
                    {
                        _statusRepositorio.Atualizar(entidade);
                        notificationResult.Add("Status atualizado com sucesso.");
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
            return _statusRepositorio.ListarTodos();
        }

        public Status BuscarPorId(int id)
        {
            if (id > 0)
                return _statusRepositorio.BuscarPorId(id);
            return null;
        }

        public NotificationResult Remover(int id)
        {
            var notificationResult = new NotificationResult();
            try
            {
                if (notificationResult.IsValid)
                {
                    _statusRepositorio.RemoverPersonalizado(id);
                    notificationResult.Add("Removido com sucesso");
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
