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
        private readonly IPedidoProdutoRepositorio _PedidoProdutoRepositorio;

        public PedidoProdutoAplicacao(IPedidoProdutoRepositorio PedidoProdutorepositorio)
        {
            _PedidoProdutoRepositorio = PedidoProdutorepositorio;
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
                        _PedidoProdutoRepositorio.Adicionar(entidade);
                        notificationResult.Add("Avaliacao cadastrada com sucesso.");
                    }
                    else
                    {
                        _PedidoProdutoRepositorio.Atualizar(entidade);
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

        public IEnumerable<PedidoProduto> ListarTodos()
        {
            return _PedidoProdutoRepositorio.ListarTodos();
        }

        public string Excluir(PedidoProduto entidade)
        {
            _PedidoProdutoRepositorio.Remover(entidade);
            return "Excluido";
        }
    }
}
