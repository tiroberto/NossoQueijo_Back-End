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
        public NotificationResult ListarPorIdUsuarioPaginado(int idUsuario, int pagina);
        public NotificationResult ListarPorPeriodoPaginado(DateTime inicio, DateTime fim, int pagina);
        public NotificationResult BuscarPorId(int id);
        public NotificationResult Remover(int id);
    }
}
