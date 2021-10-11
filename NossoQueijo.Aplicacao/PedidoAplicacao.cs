using System;
using System.Collections.Generic;
using System.Text;
using NossoQueijo.Dominio.Entidades;
using NossoQueijo.Dominio.Interfaces.Repositorio;
using NossoQueijo.Comum.NotificationPattern;
using NossoQueijo.Dominio.Interfaces.Aplicacao;

namespace AnBertoCars.Aplicacao
{
    public class PedidoAplicacao : IPedidoAplicacao
    {
        private readonly IPedidoRepositorio _PedidoRepositorio;

        public PedidoAplicacao(IPedidoRepositorio Pedidorepositorio)
        {
            _PedidoRepositorio = Pedidorepositorio;
        }

        public NotificationResult Salvar(Pedido entidade)
        {
            var notificationResult = new NotificationResult();
            try
            {
                if (notificationResult.IsValid)
                {

                    if (entidade.idPedido == 0)
                    {
                        _PedidoRepositorio.Adicionar(entidade);
                        notificationResult.Add("Avaliacao cadastrada com sucesso.");
                    }
                    else
                    {
                        _PedidoRepositorio.Atualizar(entidade);
                        notificationResult.Add("Avaliacao atualizada com sucesso.");
                    }

                }

                notificationResult.Result = entidade;

                return notificationResult;
            }
            catch (Exception ex)
            {
                return notificationResult.Add(new NotificationError(ex.Message));
            }
        }

        public IEnumerable<Pedido> ListarTodos()
        {
            return _PedidoRepositorio.ListarTodos();
        }

        public string Excluir(Pedido entidade)
        {
            _PedidoRepositorio.Remover(entidade);
            return "Excluido";
        }
    }
}
