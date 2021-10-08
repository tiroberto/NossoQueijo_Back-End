using System;
using System.Collections.Generic;
using System.Text;
using NossoQueijo.Dominio.Entidades;
using NossoQueijo.Dominio.Interfaces.Repositorio;
using NossoQueijo.Comum.NotificationPattern;
using NossoQueijo.Dominio.Interfaces.Aplicacao;

namespace AnBertoCars.Aplicacao
{
    public class CidadeAplicacao : ICidadeAplicacao
    {
        private readonly ICidadeRepositorio _CidadeRepositorio;

        public CidadeAplicacao(ICidadeRepositorio Cidaderepositorio)
        {
            _CidadeRepositorio = Cidaderepositorio;
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
                        _CidadeRepositorio.Adicionar(entidade);
                        notificationResult.Add("Avaliacao cadastrada com sucesso.");
                    }
                    else
                    {
                        _CidadeRepositorio.Atualizar(entidade);
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

        public IEnumerable<Cidade> ListarTodos()
        {
            return _CidadeRepositorio.ListarTodos();
        }

        public string Excluir(Cidade entidade)
        {
            _CidadeRepositorio.Remover(entidade);
            return "Excluido";
        }
    }
}
