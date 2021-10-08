using System;
using System.Collections.Generic;
using System.Text;
using NossoQueijo.Dominio.Entidades;
using NossoQueijo.Dominio.Interfaces.Repositorio;
using NossoQueijo.Comum.NotificationPattern;
using NossoQueijo.Dominio.Interfaces.Aplicacao;

namespace AnBertoCars.Aplicacao
{
    public class EnderecoAplicacao : IEnderecoAplicacao
    {
        private readonly IEnderecoRepositorio _EnderecoRepositorio;

        public EnderecoAplicacao(IEnderecoRepositorio Enderecorepositorio)
        {
            _EnderecoRepositorio = Enderecorepositorio;
        }

        public NotificationResult Salvar(Endereco entidade)
        {
            var notificationResult = new NotificationResult();

            try
            {
                if (notificationResult.IsValid)
                {

                    if (entidade.idEndereco == 0)
                    {
                        _EnderecoRepositorio.Adicionar(entidade);
                        notificationResult.Add("Avaliacao cadastrada com sucesso.");
                    }
                    else
                    {
                        _EnderecoRepositorio.Atualizar(entidade);
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

        public IEnumerable<Endereco> ListarTodos()
        {
            return _EnderecoRepositorio.ListarTodos();
        }

        public string Excluir(Endereco entidade)
        {
            _EnderecoRepositorio.Remover(entidade);
            return "Excluido";
        }
    }
}
