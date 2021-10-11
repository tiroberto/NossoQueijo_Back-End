using System;
using System.Collections.Generic;
using System.Text;
using NossoQueijo.Dominio.Entidades;
using NossoQueijo.Dominio.Interfaces.Repositorio;
using NossoQueijo.Comum.NotificationPattern;
using NossoQueijo.Dominio.Interfaces.Aplicacao;

namespace AnBertoCars.Aplicacao
{
    public class PedidoProdutoAplicacao : IPedidoProdutoAplicacao
    {
        private readonly IPedidoProdutoRepositorio _pedidoProdutoRepositorio;

        public PedidoProdutoAplicacao(IPedidoProdutoRepositorio pedidoProdutoRepositorio)
        {
            _pedidoProdutoRepositorio = pedidoProdutoRepositorio;
        }

        public NotificationResult Salvar(PedidoProduto entidade)
        {
            var notificationResult = new NotificationResult();

            try
            {
                if (notificationResult.IsValid)
                {

                    if (entidade.idPedido == 0 && entidade.idProduto == 0)
                    {
                        _pedidoProdutoRepositorio.Adicionar(entidade);
                        notificationResult.Add("Pedido produto cadastrado com sucesso.");
                    }
                    else
                    {
                        _pedidoProdutoRepositorio.Atualizar(entidade);
                        notificationResult.Add("Pedido produto atualizado com sucesso.");
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

        public IEnumerable<PedidoProduto> ListarTodos()
        {
            return _pedidoProdutoRepositorio.ListarTodos();
        }

        public IEnumerable<PedidoProduto> ListarPorIdPedido(int idPedido)
        {
            if (idPedido > 0)
                return _pedidoProdutoRepositorio.ListarPorIdPedido(idPedido);
            return null;
        }

        public string Excluir(PedidoProduto entidade)
        {
            _pedidoProdutoRepositorio.Remover(entidade);
            return "Excluido";
        }
    }
}
