using System;
using System.Collections.Generic;
using System.Text;
using NossoQueijo.Dominio.Entidades;
using NossoQueijo.Dominio.Interfaces.Repositorio;
using NossoQueijo.Comum.NotificationPattern;
using NossoQueijo.Dominio.Interfaces.Aplicacao;

namespace AnBertoCars.Aplicacao
{
    public class EstoquePorDataAplicacao : IEstoquePorDataAplicacao
    {
        private readonly IEstoquePorDataRepositorio _EstoquePorDataRepositorio;

        public EstoquePorDataAplicacao(IEstoquePorDataRepositorio EstoquePorDatarepositorio)
        {
            _EstoquePorDataRepositorio = EstoquePorDatarepositorio;
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
                        _EstoquePorDataRepositorio.Adicionar(entidade);
                        notificationResult.Add("Avaliacao cadastrada com sucesso.");
                    }
                    else
                    {
                        _EstoquePorDataRepositorio.Atualizar(entidade);
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

        public IEnumerable<EstoquePorData> ListarTodos()
        {
            return _EstoquePorDataRepositorio.ListarTodos();
        }

        public string Excluir(EstoquePorData entidade)
        {
            _EstoquePorDataRepositorio.Remover(entidade);
            return "Excluido";
        }
    }
}
