using System;
using System.Collections.Generic;
using System.Text;
using NossoQueijo.Dominio.Entidades;
using NossoQueijo.Dominio.Interfaces.Repositorio;
using NossoQueijo.Comum.NotificationPattern;
using NossoQueijo.Dominio.Interfaces.Aplicacao;

namespace NossoQueijo.Aplicacao
{
    public class EstoquePorDataAplicacao : IEstoquePorDataAplicacao
    {
        private readonly IEstoquePorDataRepositorio _estoquePorDataRepositorio;

        public EstoquePorDataAplicacao(IEstoquePorDataRepositorio estoquePorDataRepositorio)
        {
            _estoquePorDataRepositorio = estoquePorDataRepositorio;
        }

        public NotificationResult Salvar(EstoquePorData entidade)
        {
            var notificationResult = new NotificationResult();

            try
            {
                if (notificationResult.IsValid)
                {

                    if (entidade.idEstoquePorData == 0)
                    {
                        _estoquePorDataRepositorio.Adicionar(entidade);
                        notificationResult.Add("Estoque por data cadastrada com sucesso.");
                    }
                    else
                    {
                        _estoquePorDataRepositorio.Atualizar(entidade);
                        notificationResult.Add("Estoque por data atualizada com sucesso.");
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

        public IEnumerable<EstoquePorData> ListarTodos()
        {
            return _estoquePorDataRepositorio.ListarTodos();
        }

        public EstoquePorData BuscarPorId(int id)
        {
            if (id > 0)
                return _estoquePorDataRepositorio.BuscarPorId(id);
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
                        && (fim != null) 
                        && (inicio < fim) 
                        && (inicio < DateTime.Now))
                    {
                        notificationResult.Result = _estoquePorDataRepositorio.ListarPorPeriodo(inicio, fim);
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

        public IEnumerable<EstoquePorData> ListaPorIdProduto(int idProduto)
        {
            if (idProduto > 0)
                return _estoquePorDataRepositorio.ListarPorIdProduto(idProduto);
            return null;
        }

        public NotificationResult Remover(int id)
        {
            var notificationResult = new NotificationResult();
            EstoquePorData estoquePorData = new EstoquePorData();
            estoquePorData.idEstoquePorData = id;
            try
            {
                if (notificationResult.IsValid)
                {
                    _estoquePorDataRepositorio.Remover(estoquePorData);
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
