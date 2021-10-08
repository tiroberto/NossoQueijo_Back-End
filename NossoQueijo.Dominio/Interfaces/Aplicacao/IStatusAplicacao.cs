using NossoQueijo.Comum.NotificationPattern;
using NossoQueijo.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace NossoQueijo.Dominio.Interfaces.Aplicacao
{
    public interface IStatusAplicacao
    {
        public NotificationResult Salvar(Status entidade);

        public IEnumerable<Status> ListarTodos();

        public string Excluir(Status entidade);
    }
}
