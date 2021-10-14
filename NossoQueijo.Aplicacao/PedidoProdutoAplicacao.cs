using System;
using System.Collections.Generic;
using System.Text;
using NossoQueijo.Dominio.Entidades;
using NossoQueijo.Dominio.Interfaces.Repositorio;
using NossoQueijo.Comum.NotificationPattern;
using NossoQueijo.Dominio.Interfaces.Aplicacao;

namespace NossoQueijo.Aplicacao
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

        public NotificationResult Remover(int idPedido, int idProduto)
        {
            var notificationResult = new NotificationResult();
            PedidoProduto pedidoProduto = new PedidoProduto();
            pedidoProduto.idPedido = idPedido;
            pedidoProduto.idProduto = idProduto;
            try
            {
                if (notificationResult.IsValid)
                {
                    _pedidoProdutoRepositorio.Remover(pedidoProduto);
                    notificationResult.Add("Removido com sucesso");
                }
                return notificationResult;
            }
            catch (Exception ex)
            {
                return notificationResult.Add(new NotificationError(ex.Message));
            }
        }
    }
}
