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
                        _cidadeRepositorio.Adicionar(entidade);
                        notificationResult.Add("Cidade cadastrada com sucesso.");
                    }
                    else
                    {
                        _cidadeRepositorio.Atualizar(entidade);
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

        public Cidade BuscarPorId(int id)
        {
            return _cidadeRepositorio.BuscarPorId(id);
        }

        public IEnumerable<Cidade> ListarPorIdCidade(int idCidade)
        {
            return _cidadeRepositorio.ListarPorIdEstado(idCidade);
        }

        public bool Excluir(Cidade entidade)
        {
            if (_cidadeRepositorio.Remover(entidade))
                return true;
            else
                return false;
        }
    }
}
