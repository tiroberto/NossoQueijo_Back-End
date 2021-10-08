using NossoQueijo.Comum.NotificationPattern;
using NossoQueijo.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace NossoQueijo.Dominio.Interfaces.Aplicacao
{
    public interface IEstoquePorDataAplicacao
    {
        public NotificationResult Salvar(EstoquePorData entidade);

        public IEnumerable<EstoquePorData> ListarTodos();

        public string Excluir(EstoquePorData entidade);
    }
}
