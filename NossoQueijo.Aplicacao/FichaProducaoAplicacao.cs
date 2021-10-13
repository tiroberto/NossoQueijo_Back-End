using System;
using System.Collections.Generic;
using System.Text;
using NossoQueijo.Dominio.Entidades;
using NossoQueijo.Dominio.Interfaces.Repositorio;
using NossoQueijo.Comum.NotificationPattern;
using NossoQueijo.Dominio.Interfaces.Aplicacao;

namespace NossoQueijo.Aplicacao
{
    public class FichaProducaoAplicacao : IFichaProducaoAplicacao
    {
        private readonly IFichaProducaoRepositorio _fichaProducaoRepositorio;

        public FichaProducaoAplicacao(IFichaProducaoRepositorio fichaProducaoRepositorio)
        {
            _fichaProducaoRepositorio = fichaProducaoRepositorio;
        }

        public NotificationResult Salvar(FichaProducao entidade)
        {
            var notificationResult = new NotificationResult();

            try
            {
                if (notificationResult.IsValid)
                {

                    if (entidade.idFichaProducao == 0)
                    {
                        _fichaProducaoRepositorio.Adicionar(entidade);
                        notificationResult.Add("Ficha de produção cadastrada com sucesso.");
                    }
                    else
                    {
                        _fichaProducaoRepositorio.Atualizar(entidade);
                        notificationResult.Add("Ficha de produção atualizada com sucesso.");
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

        public IEnumerable<FichaProducao> ListarTodos()
        {
            return _fichaProducaoRepositorio.ListarTodos();
        }

        public IEnumerable<FichaProducao> ListarPorIdUsuario(int idUsuario)
        {
            if (idUsuario > 0)
                return _fichaProducaoRepositorio.ListarPorIdUsuario(idUsuario);
            return null;
        }

        public NotificationResult ListarPorPeriodo(DateTime inicio, DateTime fim)
        {
            var notificationResult = new NotificationResult();

            try
            {
                if (notificationResult.IsValid)
                {

                    if ((inicio != null)
                        || (fim != null)
                        || (inicio < fim)
                        || (inicio < DateTime.Now))
                    {
                        notificationResult.Result = _fichaProducaoRepositorio.ListarPorPeriodo(inicio, fim);
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

        public FichaProducao BuscarPorId(int id)
        {
            if (id > 0)
                return _fichaProducaoRepositorio.BuscarPorId(id);
            return null;
        }

        public string Excluir(FichaProducao entidade)
        {
            _fichaProducaoRepositorio.Remover(entidade);
            return "Excluido";
        }
    }
}
