using NossoQueijo.Comum.NotificationPattern;
using NossoQueijo.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace NossoQueijo.Dominio.Interfaces.Aplicacao
{
    public interface IFichaProducaoAplicacao
    {
        public NotificationResult Salvar(FichaProducao entidade);
        public IEnumerable<FichaProducao> ListarTodos();
        public IEnumerable<FichaProducao> ListarPorIdUsuario(int idUsuario);
        public NotificationResult ListarPorPeriodo(DateTime inicio, DateTime fim);
        public FichaProducao BuscarPorId(int id);
        public NotificationResult Remover(int id);
    }
}
