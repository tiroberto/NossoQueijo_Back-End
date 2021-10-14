using System;
using System.Collections.Generic;
using System.Text;
using NossoQueijo.Dominio.Entidades;
using NossoQueijo.Dominio.Interfaces.Repositorio;
using NossoQueijo.Comum.NotificationPattern;
using NossoQueijo.Dominio.Interfaces.Aplicacao;

namespace NossoQueijo.Aplicacao
{
    public class EstadoAplicacao : IEstadoAplicacao
    {
        private readonly IEstadoRepositorio _estadoRepositorio;

        public EstadoAplicacao(IEstadoRepositorio estadoRepositorio)
        {
            _estadoRepositorio = estadoRepositorio;
        }

        public NotificationResult Salvar(Estado entidade)
        {
            var notificationResult = new NotificationResult();

            try
            {
                if (notificationResult.IsValid)
                {

                    if (entidade.idEstado == 0)
                    {
                        _estadoRepositorio.Adicionar(entidade);
                        notificationResult.Add("Estado cadastrado com sucesso.");
                    }
                    else
                    {
                        _estadoRepositorio.Atualizar(entidade);
                        notificationResult.Add("Estado atualizado com sucesso.");
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

        public IEnumerable<Estado> ListarTodos()
        {
            return _estadoRepositorio.ListarTodos();
        }

        public Estado BuscarPorId(int id)
        {
            if (id > 0)
                return _estadoRepositorio.BuscarPorId(id);
            return null;
        }

        public NotificationResult Remover(int id)
        {
            var notificationResult = new NotificationResult();
            Estado estado = new Estado();
            estado.idEstado = id;
            try
            {
                if (notificationResult.IsValid)
                {
                    _estadoRepositorio.Remover(estado);
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
