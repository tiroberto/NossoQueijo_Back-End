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
        public EstoquePorData BuscarPorId(int id);
        public NotificationResult ListarPorPeriodo(DateTime inicio, DateTime fim);
        public IEnumerable<EstoquePorData> ListaPorIdProduto(int idProduto);
        public NotificationResult Remover(int id);
    }
}
