using NossoQueijo.Comum.NotificationPattern;
using NossoQueijo.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace NossoQueijo.Dominio.Interfaces.Aplicacao
{
    public interface IEstadoAplicacao
    {
        public NotificationResult Salvar(Estado entidade);
        public IEnumerable<Estado> ListarTodos();
        public NotificationResult BuscarPorId(int id);
        public NotificationResult Remover(int id);
    }
}
