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
                        entidade.EstoquePorData.Quantidade = entidade.QntdProduzida;
                        _fichaProducaoRepositorio.AdicionarPersonalizado(entidade);
                        notificationResult.Add("Ficha de produção cadastrada com sucesso.");
                    }
                    else
                    {
                        _fichaProducaoRepositorio.AtualizarPersonalizado(entidade);
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

        public NotificationResult ListarPorIdUsuario(int idUsuario)
        {
            var notificationResult = new NotificationResult();
            try
            {
                if (notificationResult.IsValid)
                {
                    notificationResult.Result = _fichaProducaoRepositorio.ListarPorIdUsuario(idUsuario);
                    notificationResult.Add("Encontrado com sucesso!");
                }
                return notificationResult;
            }
            catch (Exception ex)
            {
                return notificationResult.Add(new NotificationError(ex.Message));
            }
        }

        public NotificationResult ListarPorPeriodo(DateTime inicio, DateTime fim)
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

        public NotificationResult BuscarPorId(int id)
        {
            var notificationResult = new NotificationResult();
            try
            {
                if (notificationResult.IsValid)
                {
                    notificationResult.Result = _fichaProducaoRepositorio.BuscarPorId(id);
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
                    _fichaProducaoRepositorio.RemoverPersonalizado(id);
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
