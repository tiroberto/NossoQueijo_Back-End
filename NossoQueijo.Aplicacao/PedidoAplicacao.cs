using System;
using System.Collections.Generic;
using System.Text;
using NossoQueijo.Dominio.Entidades;
using NossoQueijo.Dominio.Interfaces.Repositorio;
using NossoQueijo.Comum.NotificationPattern;
using NossoQueijo.Dominio.Interfaces.Aplicacao;
using System.Threading.Tasks;

namespace NossoQueijo.Aplicacao
{
    public class PedidoAplicacao : IPedidoAplicacao
    {
        private readonly IPedidoRepositorio _pedidoRepositorio;

        public PedidoAplicacao(IPedidoRepositorio pedidoRepositorio)
        {
            _pedidoRepositorio = pedidoRepositorio;
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
                        _pedidoRepositorio.AdicionarPersonalizado(entidade);
                        
                        //_pedidoProdutoAplicacao.AdicionarEmMassa(entidade.PedidoProdutos);
                        notificationResult.Add("Pedido cadastrado com sucesso.");
                    }
                    else
                    {
                        _pedidoRepositorio.AtualizarPersonalizado(entidade);
                        //_pedidoProdutoAplicacao.AtualizarEmMassa(entidade.PedidoProdutos);
                        notificationResult.Add("Pedido atualizado com sucesso.");
                    }
                }
                notificationResult.Result = _pedidoRepositorio.UltimoAdicionado();
                return  notificationResult;
            }
            catch (Exception ex)
            {
                return notificationResult.Add(new NotificationError(ex.Message));
            }
        }

        public IEnumerable<Pedido> ListarTodos()
        {
            return _pedidoRepositorio.ListarTodos();
        }

        public NotificationResult ListarPorIdUsuario(int idUsuario)
        {
            var notificationResult = new NotificationResult();
            try
            {
                if (notificationResult.IsValid)
                {
                    notificationResult.Result = _pedidoRepositorio.ListarPorIdUsuario(idUsuario);
                    notificationResult.Add("Pedidos encontrados com sucesso!");
                }
                return notificationResult;
            }
            catch (Exception ex)
            {
                return notificationResult.Add(new NotificationError(ex.Message));
            }
        }

        public NotificationResult ListarPorIdStatus(int idStatus)
        {
            var notificationResult = new NotificationResult();
            try
            {
                if (notificationResult.IsValid)
                {
                    notificationResult.Result = _pedidoRepositorio.ListarPorIdStatus(idStatus);
                    notificationResult.Add("Pedidos encontrados com sucesso!");
                }
                return notificationResult;
            }
            catch (Exception ex)
            {
                return notificationResult.Add(new NotificationError(ex.Message));
            }
        }

        public NotificationResult ListarPorIdFormaPagamento(int idFormaPagamento)
        {
            var notificationResult = new NotificationResult();
            try
            {
                if (notificationResult.IsValid)
                {
                    notificationResult.Result = _pedidoRepositorio.ListarPorIdFormaPagamento(idFormaPagamento);
                    notificationResult.Add("Pedidos encontrados com sucesso!");
                }
                return notificationResult;
            }
            catch (Exception ex)
            {
                return notificationResult.Add(new NotificationError(ex.Message));
            }
        }

        public NotificationResult BuscarPorId(int id)
        {
            var notificationResult = new NotificationResult();
            try
            {
                if (notificationResult.IsValid)
                {
                    notificationResult.Result = _pedidoRepositorio.BuscarPorId(id);
                    notificationResult.Add("Encontrado com sucesso!");
                }
                return notificationResult;
            }
            catch (Exception ex)
            {
                return notificationResult.Add(new NotificationError(ex.Message));
            }
        }

        public NotificationResult Remover(int id)
        {
            var notificationResult = new NotificationResult();
            try
            {
                if (notificationResult.IsValid)
                {
                    _pedidoRepositorio.RemoverPersonalizado(id);
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
