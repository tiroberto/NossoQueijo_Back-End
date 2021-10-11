using NossoQueijo.Comum.NotificationPattern;
using NossoQueijo.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace NossoQueijo.Dominio.Interfaces.Aplicacao
{
    public interface IEnderecoAplicacao
    {
        public NotificationResult Salvar(Endereco entidade);
        public IEnumerable<Endereco> ListarTodos();
        public Endereco BuscarPorId(int id);
        public IEnumerable<Endereco> ListarPorIdCidade(int idCidade);
        public bool Remover(Endereco entidade);
    }
}
