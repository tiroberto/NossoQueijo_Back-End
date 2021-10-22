using System;
using System.Collections.Generic;
using System.Text;
using NossoQueijo.Dominio.Entidades;
using NossoQueijo.Dominio.Interfaces.Repositorio;
using NossoQueijo.Comum.NotificationPattern;
using NossoQueijo.Dominio.Interfaces.Aplicacao;

namespace NossoQueijo.Aplicacao
{
    public class CidadeAplicacao : ICidadeAplicacao
    {
        private readonly ICidadeRepositorio _cidadeRepositorio;

        public CidadeAplicacao(ICidadeRepositorio cidadeRepositorio)
        {
            _cidadeRepositorio = cidadeRepositorio;
        }

        public NotificationResult Salvar(Cidade entidade)
        {
            var notificationResult = new NotificationResult();

            try
            {
                if (notificationResult.IsValid)
                {

                    if (entidade.idCidade == 0)
                    {
                        _cidadeRepositorio.AdicionarPersonalizado(entidade);
                        notificationResult.Add("Cidade cadastrada com sucesso.");
                    }
                    else
                    {
                        _cidadeRepositorio.AtualizarPersonalizado(entidade);
                        notificationResult.Add("Cidade atualizada com sucesso.");
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

        public IEnumerable<Cidade> ListarTodos()
        {
            return _cidadeRepositorio.ListarTodos();
        }

        public NotificationResult BuscarPorId(int id)
        {
            var notificationResult = new NotificationResult();
            try
            {
                if (notificationResult.IsValid)
                {
                    notificationResult.Result = _cidadeRepositorio.BuscarPorId(id);
                    notificationResult.Add("Encontrado com sucesso!");
                }
                return notificationResult;
            }
            catch (Exception ex)
            {
                return notificationResult.Add(new NotificationError(ex.Message));
            }
        }

        public IEnumerable<Cidade> ListarPorIdEstado(int idEstado)
        {
            return _cidadeRepositorio.ListarPorIdEstado(idEstado);
        }

        public NotificationResult Remover(int id)
        {
            var notificationResult = new NotificationResult();
            Cidade cidade = new Cidade();
            cidade.idCidade = id;
            try
            {
                if (notificationResult.IsValid)
                {
                    _cidadeRepositorio.Remover(cidade);
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
