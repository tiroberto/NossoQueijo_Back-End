using NossoQueijo.Dominio.Entidades;
using NossoQueijo.Dominio.Interfaces.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NossoQueijo.Repositorio.RepositoriosEF
{
    public class FormaPagamentoRepositorio : RepositorioBase<FormaPagamento> , IFormaPagamentoRepositorio
    {
        private Contexto _contexto;

        public FormaPagamentoRepositorio()
        {
            _contexto = new Contexto();
        }

        public IEnumerable<FormaPagamento> ListarTodos()
        {
            return _contexto.FormasPagamento
                .ToList();
                
        }

        public FormaPagamento BuscarPorId(int id)
        {
            return _contexto.FormasPagamento
                .First(x => x.idFormaPagamento == id);
        }

        public bool RemoverPersonalizado(int id)
        {
            FormaPagamento formaPagamentoRemover = _contexto.FormasPagamento.First(x => x.idFormaPagamento == id);
            IEnumerable<Pedido> pedidosAtualizar = _contexto.Pedidos.Where(x => x.FormaPagamento.idFormaPagamento == id).ToList();
            foreach(var item in pedidosAtualizar)
            {
                item.FormaPagamento.idFormaPagamento = 0;
            }
            _contexto.Pedidos
                .UpdateRange(pedidosAtualizar);
            _contexto.Remove(formaPagamentoRemover);
            _contexto.SaveChanges();
            return true;
        }
    }
}
