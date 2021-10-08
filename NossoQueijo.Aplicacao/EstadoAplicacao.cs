using System;
using System.Collections.Generic;
using System.Text;
using NossoQueijo.Dominio.Entidades;
using NossoQueijo.Dominio.Interfaces.Repositorio;
using NossoQueijo.Comum.NotificationPattern;
using NossoQueijo.Dominio.Interfaces.Aplicacao;

namespace AnBertoCars.Aplicacao
{
    public class EstadoAplicacao : IEstadoAplicacao
    {
        private readonly IEstadoRepositorio _EstadoRepositorio;

        public EstadoAplicacao(IEstadoRepositorio Estadorepositorio)
        {
            _EstadoRepositorio = Estadorepositorio;
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
                        _EstadoRepositorio.Adicionar(entidade);
                        notificationResult.Add("Avaliacao cadastrada com sucesso.");
                    }
                    else
                    {
                        _EstadoRepositorio.Atualizar(entidade);
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

        public IEnumerable<Estado> ListarTodos()
        {
            return _EstadoRepositorio.ListarTodos();
        }

        public string Excluir(Estado entidade)
        {
            _EstadoRepositorio.Remover(entidade);
            return "Excluido";
        }
    }
}
