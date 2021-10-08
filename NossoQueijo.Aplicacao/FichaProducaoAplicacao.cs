using System;
using System.Collections.Generic;
using System.Text;
using NossoQueijo.Dominio.Entidades;
using NossoQueijo.Dominio.Interfaces.Repositorio;
using NossoQueijo.Comum.NotificationPattern;
using NossoQueijo.Dominio.Interfaces.Aplicacao;

namespace AnBertoCars.Aplicacao
{
    public class FichaProducaoAplicacao : IFichaProducaoAplicacao
    {
        private readonly IFichaProducaoRepositorio _FichaProducaoRepositorio;

        public FichaProducaoAplicacao(IFichaProducaoRepositorio FichaProducaorepositorio)
        {
            _FichaProducaoRepositorio = FichaProducaorepositorio;
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
                        _FichaProducaoRepositorio.Adicionar(entidade);
                        notificationResult.Add("Avaliacao cadastrada com sucesso.");
                    }
                    else
                    {
                        _FichaProducaoRepositorio.Atualizar(entidade);
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

        public IEnumerable<FichaProducao> ListarTodos()
        {
            return _FichaProducaoRepositorio.ListarTodos();
        }

        public string Excluir(FichaProducao entidade)
        {
            _FichaProducaoRepositorio.Remover(entidade);
            return "Excluido";
        }
    }
}
