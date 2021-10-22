using NossoQueijo.Comum.NotificationPattern;
using NossoQueijo.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace NossoQueijo.Dominio.Interfaces.Aplicacao
{
    public interface IEstoquePorDataAplicacao
    {
        public NotificationResult Adicionar(EstoquePorData entidade);
        public NotificationResult Atualizar(EstoquePorData entidade);
        public IEnumerable<EstoquePorData> ListarTodos();
        public NotificationResult BuscarPorIdFichaProducao(int idFichaProducao);
        public NotificationResult ListarPorPeriodo(DateTime inicio, DateTime fim);
        public NotificationResult ListaPorIdProduto(int idProduto);
        public NotificationResult Remover(EstoquePorData estoquePorData);
    }
}
