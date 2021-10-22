using NossoQueijo.Comum.NotificationPattern;
using NossoQueijo.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace NossoQueijo.Dominio.Interfaces.Aplicacao
{
    public interface ICidadeAplicacao
    {
        public NotificationResult Salvar(Cidade entidade);
        public IEnumerable<Cidade> ListarTodos();
        public NotificationResult BuscarPorId(int id);
        public IEnumerable<Cidade> ListarPorIdEstado(int idEstado);
        public NotificationResult Remover(int id);
    }
}
