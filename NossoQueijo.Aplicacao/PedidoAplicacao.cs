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
                        entidade.idPedido = _pedidoRepositorio.AdicionarPersonalizado(entidade);
                        notificationResult.Add("Pedido cadastrado com sucesso.");
                        if(entidade.idPedido > 0)
                        {
                            notificationResult.Result = entidade;
                            return notificationResult;
                        }
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

        public dynamic ListarTodosPaginado(int pagina)
        {
            return _pedidoRepositorio.ListarTodosPaginado(pagina);
        }

        public IEnumerable<Pedido> ListarTodos()
        {
            return _pedidoRepositorio.ListarTodos();
        }

        public NotificationResult ListarPorIdUsuarioPaginado(int idUsuario, int pagina)
        {
            var notificationResult = new NotificationResult();
            try
            {
                if (notificationResult.IsValid)
                {
                    notificationResult.Result = _pedidoRepositorio.ListarPorIdUsuarioPaginado(idUsuario, pagina);
                    notificationResult.Add("Pedidos encontrados com sucesso!");
                }
                return notificationResult;
            }
            catch (Exception ex)
            {
                return notificationResult.Add(new NotificationError(ex.Message));
            }
        }

        public NotificationResult ListarPorIdStatusPaginado(int idStatus, int pagina)
        {
            var notificationResult = new NotificationResult();
            try
            {
                if (notificationResult.IsValid)
                {
                    notificationResult.Result = _pedidoRepositorio.ListarPorIdStatusPaginado(idStatus, pagina);
                    notificationResult.Add("Pedidos encontrados com sucesso!");
                }
                return notificationResult;
            }
            catch (Exception ex)
            {
                return notificationResult.Add(new NotificationError(ex.Message));
            }
        }

        public NotificationResult ListarPorIdFormaPagamentoPaginado(int idFormaPagamento, int pagina)
        {
            var notificationResult = new NotificationResult();
            try
            {
                if (notificationResult.IsValid)
                {
                    notificationResult.Result = _pedidoRepositorio.ListarPorIdFormaPagamentoPaginado(idFormaPagamento, pagina);
                    notificationResult.Add("Pedidos encontrados com sucesso!");
                }
                return notificationResult;
            }
            catch (Exception ex)
            {
                return notificationResult.Add(new NotificationError(ex.Message));
            }
        }

        public NotificationResult ListarPorPeriodoPaginado(DateTime inicio, DateTime fim, int pagina)
        {
            var notificationResult = new NotificationResult();

            try
            {
                if (notificationResult.IsValid)
                {

                    if ((inicio != null)
                        && (fim != null)
                        && (inicio < fim)
                        && (inicio < DateTime.Now))
                    {
                        notificationResult.Result = _pedidoRepositorio.ListarPorPeriodoPaginado(inicio, fim, pagina);
                        notificationResult.Add("Lista gerada com sucesso.");
                    }

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
                    notificationResult.Result = true;
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
