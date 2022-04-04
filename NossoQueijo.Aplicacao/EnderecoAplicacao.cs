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
                        entidade.idEndereco = _enderecoRepositorio.AdicionarPersonalizado(entidade);
                        notificationResult.Add("Endereço cadastrado com sucesso.");
                        if (entidade.idEndereco > 0)
                        {
                            notificationResult.Result = entidade;
                            return notificationResult;
                        }
                    }
                    else
                    {
                        _enderecoRepositorio.AtualizarPersonalizado(entidade);
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

        public NotificationResult BuscarPorId(int id)
        {
            var notificationResult = new NotificationResult();
            try
            {
                if (notificationResult.IsValid)
                {
                    notificationResult.Result = _enderecoRepositorio.BuscarPorId(id);
                    notificationResult.Add("Encontrado com sucesso!");
                }
                return notificationResult;
            }
            catch (Exception ex)
            {
                return notificationResult.Add(new NotificationError(ex.Message));
            }
        }

        public IEnumerable<Endereco> ListarPorIdCidade(int idCidade)
        {
            return _enderecoRepositorio.ListarPorIdCidade(idCidade);
        }

       public NotificationResult Remover(int id)
        {
            var notificationResult = new NotificationResult();
            Endereco endereco = new Endereco();
            endereco.idEndereco = id;
            try
            {
                if (notificationResult.IsValid)
                {
                    _enderecoRepositorio.Remover(endereco);
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
