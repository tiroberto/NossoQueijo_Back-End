using NossoQueijo.Comum.NotificationPattern;
using NossoQueijo.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace NossoQueijo.Dominio.Interfaces.Aplicacao
{
    public interface IFormaPagamentoAplicacao
    {
        public NotificationResult Salvar(FormaPagamento entidade);

        public IEnumerable<FormaPagamento> ListarTodos();

        public string Excluir(FormaPagamento entidade);
    }
}
