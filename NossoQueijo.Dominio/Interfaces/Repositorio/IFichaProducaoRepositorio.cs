using NossoQueijo.Comum.NotificationPattern;
using NossoQueijo.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace NossoQueijo.Dominio.Interfaces.Repositorio
{
    public interface IFichaProducaoRepositorio : IRepositorioBase<FichaProducao>
    {
        public IEnumerable<FichaProducao> ListarTodos();
        public IEnumerable<FichaProducao> ListarPorIdUsuario(int idUsuario);
        public IEnumerable<FichaProducao> ListarPorPeriodo(DateTime inicio, DateTime fim);
        public FichaProducao BuscarPorId(int id);
        public bool RemoverPersonalizado(int id);
    }
}
