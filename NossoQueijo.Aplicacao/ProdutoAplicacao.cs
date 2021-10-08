using System;
using System.Collections.Generic;
using System.Text;
using NossoQueijo.Dominio.Entidades;
using NossoQueijo.Dominio.Interfaces.Repositorio;
using NossoQueijo.Comum.NotificationPattern;
using NossoQueijo.Dominio.Interfaces.Aplicacao;

namespace AnBertoCars.Aplicacao
{
    public class ProdutoAplicacao : IProdutoAplicacao
    {
        private readonly IProdutoRepositorio _ProdutoRepositorio;

        public ProdutoAplicacao(IProdutoRepositorio Produtorepositorio)
        {
            _ProdutoRepositorio = Produtorepositorio;
        }

        public NotificationResult Salvar(Produto entidade)
        {
            var notificationResult = new NotificationResult();

            try
            {
                if (notificationResult.IsValid)
                {

                    if (entidade.idProduto == 0)
                    {
                        _ProdutoRepositorio.Adicionar(entidade);
                        notificationResult.Add("Avaliacao cadastrada com sucesso.");
                    }
                    else
                    {
                        _ProdutoRepositorio.Atualizar(entidade);
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

        public IEnumerable<Produto> ListarTodos()
        {
            return _ProdutoRepositorio.ListarTodos();
        }

        public string Excluir(Produto entidade)
        {
            _ProdutoRepositorio.Remover(entidade);
            return "Excluido";
        }
    }
}
