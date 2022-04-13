using System;
using System.Collections.Generic;
using System.Text;
using NossoQueijo.Dominio.Entidades;
using NossoQueijo.Dominio.Interfaces.Repositorio;
using NossoQueijo.Comum.NotificationPattern;
using NossoQueijo.Dominio.Interfaces.Aplicacao;
using System.Threading.Tasks;
using System.Globalization;
using System.Collections;
using System.Linq;

namespace NossoQueijo.Aplicacao
{
    public class ProdutoAplicacao : IProdutoAplicacao
    {
        private readonly IProdutoRepositorio _produtoRepositorio;

        public ProdutoAplicacao(IProdutoRepositorio produtoRepositorio)
        {
            _produtoRepositorio = produtoRepositorio;
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
                        entidade.idProduto = _produtoRepositorio.Adicionar(entidade).idProduto;
                        notificationResult.Add("Produto cadastrado com sucesso.");
                        if(entidade.idProduto > 0)
                        {
                            notificationResult.Result = entidade;
                            return notificationResult;
                        }
                    }
                    else
                    {
                        _produtoRepositorio.Atualizar(entidade);
                        notificationResult.Add("Produto atualizado com sucesso.");
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
            return _produtoRepositorio.ListarTodos();
        }

        public dynamic ListarTodosPaginado(int pagina)
        {
            return _produtoRepositorio.ListarTodosPaginado(pagina);
        }

        public NotificationResult BuscarPorId(int id)
        {
            var notificationResult = new NotificationResult();
            try
            {
                if (notificationResult.IsValid)
                {
                    notificationResult.Result = _produtoRepositorio.BuscarPorId(id);
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
                    _produtoRepositorio.RemoverPersonalizado(id);
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
