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
                        _pedidoRepositorio.Adicionar(entidade);
                        notificationResult.Add("Pedido cadastrado com sucesso.");
                    }
                    else
                    {
                        _pedidoRepositorio.Atualizar(entidade);
                        notificationResult.Add("Pedido atualizado com sucesso.");
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
            return _pedidoRepositorio.ListarTodos();
        }

        public IEnumerable<Pedido> ListarPorIdUsuario(int idUsuario)
        {
            if (idUsuario > 0)
                return _pedidoRepositorio.ListarPorIdUsuario(idUsuario);
            return null;
        }

        public IEnumerable<Pedido> ListarPorIdStatus(int idStatus)
        {
            if (idStatus > 0)
                return _pedidoRepositorio.ListarPorIdUsuario(idStatus);
            return null;
        }

        public IEnumerable<Pedido> ListarPorIdFormaPagamento(int idFormaPagamento)
        {
            if (idFormaPagamento > 0)
                return _pedidoRepositorio.ListarPorIdUsuario(idFormaPagamento);
            return null;
        }

        public Pedido BuscarPorId(int id)
        {
            if (id > 0)
                return _pedidoRepositorio.BuscarPorId(id);
            return null;
        }

        public NotificationResult RemoverPersonalizado(int id)
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
