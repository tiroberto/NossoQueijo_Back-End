using System;
using System.Collections.Generic;
using System.Text;
using NossoQueijo.Dominio.Entidades;
using NossoQueijo.Dominio.Interfaces.Repositorio;
using NossoQueijo.Comum.NotificationPattern;
using NossoQueijo.Dominio.Interfaces.Aplicacao;

namespace AnBertoCars.Aplicacao
{
    public class FormaPagamentoAplicacao : IFormaPagamentoAplicacao
    {
        private readonly IFormaPagamentoRepositorio _FormaPagamentoRepositorio;

        public FormaPagamentoAplicacao(IFormaPagamentoRepositorio FormaPagamentorepositorio)
        {
            _FormaPagamentoRepositorio = FormaPagamentorepositorio;
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
                        _FormaPagamentoRepositorio.Adicionar(entidade);
                        notificationResult.Add("Avaliacao cadastrada com sucesso.");
                    }
                    else
                    {
                        _FormaPagamentoRepositorio.Atualizar(entidade);
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

        public IEnumerable<FormaPagamento> ListarTodos()
        {
            return _FormaPagamentoRepositorio.ListarTodos();
        }

        public string Excluir(FormaPagamento entidade)
        {
            _FormaPagamentoRepositorio.Remover(entidade);
            return "Excluido";
        }
    }
}
