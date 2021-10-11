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
        public FormaPagamento BuscarPorId(int id);
        public NotificationResult RemoverPersonalizado(int id);
    }
}
