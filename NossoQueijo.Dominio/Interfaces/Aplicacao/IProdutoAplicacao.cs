using NossoQueijo.Comum.NotificationPattern;
using NossoQueijo.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NossoQueijo.Dominio.Interfaces.Aplicacao
{
    public interface IProdutoAplicacao
    {
        public NotificationResult Salvar(Produto entidade);
        public IEnumerable<Produto> ListarTodos();
        public dynamic ListarTodosPaginado(int pagina);
        public NotificationResult BuscarPorId(int id);
        public NotificationResult Remover(int id);
    }
}
