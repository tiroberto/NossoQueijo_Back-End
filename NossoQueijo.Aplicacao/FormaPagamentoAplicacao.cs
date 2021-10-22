using System;
using System.Collections.Generic;
using System.Text;
using NossoQueijo.Dominio.Entidades;
using NossoQueijo.Dominio.Interfaces.Repositorio;
using NossoQueijo.Comum.NotificationPattern;
using NossoQueijo.Dominio.Interfaces.Aplicacao;

namespace NossoQueijo.Aplicacao
{
    public class FormaPagamentoAplicacao : IFormaPagamentoAplicacao
    {
        private readonly IFormaPagamentoRepositorio _formaPagamentoRepositorio;

        public FormaPagamentoAplicacao(IFormaPagamentoRepositorio formaPagamentoRepositorio)
        {
            _formaPagamentoRepositorio = formaPagamentoRepositorio;
        }

        public NotificationResult Salvar(FormaPagamento entidade)
        {
            var notificationResult = new NotificationResult();

            try
            {
                if (notificationResult.IsValid)
                {

                    if (entidade.idFormaPagamento == 0)
                    {
                        _formaPagamentoRepositorio.Adicionar(entidade);
                        notificationResult.Add("Forma de pagamento cadastrada com sucesso.");
                    }
                    else
                    {
                        _formaPagamentoRepositorio.Atualizar(entidade);
                        notificationResult.Add("Forma de pagamento atualizada com sucesso.");
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

        public IEnumerable<FormaPagamento> ListarTodos()
        {
            return _formaPagamentoRepositorio.ListarTodos();
        }

        public NotificationResult BuscarPorId(int id)
        {
            var notificationResult = new NotificationResult();
            try
            {
                if (notificationResult.IsValid)
                {
                    notificationResult.Result = _formaPagamentoRepositorio.BuscarPorId(id);
                    notificationResult.Add("Encontrado com sucesso!");
                }
                return notificationResult;
            }
            catch (Exception ex)
            {
                return notificationResult.Add(new NotificationError(ex.Message));
            }
        }

        public NotificationResult Remover(int id)
        {
            var notificationResult = new NotificationResult();
            try
            {
                if (notificationResult.IsValid)
                {
                    _formaPagamentoRepositorio.RemoverPersonalizado(id);
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
