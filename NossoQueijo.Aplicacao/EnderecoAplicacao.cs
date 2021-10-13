using System;
using System.Collections.Generic;
using System.Text;
using NossoQueijo.Dominio.Entidades;
using NossoQueijo.Dominio.Interfaces.Repositorio;
using NossoQueijo.Comum.NotificationPattern;
using NossoQueijo.Dominio.Interfaces.Aplicacao;

namespace NossoQueijo.Aplicacao
{
    public class EnderecoAplicacao : IEnderecoAplicacao
    {
        private readonly IEnderecoRepositorio _enderecoRepositorio;

        public EnderecoAplicacao(IEnderecoRepositorio enderecoRepositorio)
        {
            _enderecoRepositorio = enderecoRepositorio;
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
                        _enderecoRepositorio.Adicionar(entidade);
                        notificationResult.Add("Endereço cadastrado com sucesso.");
                    }
                    else
                    {
                        _enderecoRepositorio.Atualizar(entidade);
                        notificationResult.Add("Endereço atualizado com sucesso.");
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
            return _enderecoRepositorio.ListarTodos();
        }

        public Endereco BuscarPorId(int id)
        {
            if (id > 0)
                return _enderecoRepositorio.BuscarPorId(id);
            return null;
        }

        public IEnumerable<Endereco> ListarPorIdCidade(int idCidade)
        {
            if (idCidade > 0)
                return _enderecoRepositorio.ListarPorIdCidade(idCidade);           
            return null;
        }

        public bool Remover(Endereco entidade)
        {
            if (_enderecoRepositorio.Remover(entidade))
                return true;
            else
                return false;
        }
    }
}
