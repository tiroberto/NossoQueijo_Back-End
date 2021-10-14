using NossoQueijo.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace NossoQueijo.Dominio.Interfaces.Repositorio
{
    public interface IEnderecoRepositorio : IRepositorioBase<Endereco>
    {
        public void AdicionarPersonalizado(Endereco endereco);
        public void AtualizarPersonalizado(Endereco endereco);
        public IEnumerable<Endereco> ListarTodos();
        public Endereco BuscarPorId(int id);
        public IEnumerable<Endereco> ListarPorIdCidade(int idCidade);
    }
}
