using Microsoft.EntityFrameworkCore;
using NossoQueijo.Dominio.Entidades;
using NossoQueijo.Dominio.Interfaces.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NossoQueijo.Repositorio.RepositoriosEF
{
    public class EnderecoRepositorio : RepositorioBase<Endereco> , IEnderecoRepositorio
    {
        private Contexto _contexto;

        public EnderecoRepositorio()
        {
            _contexto = new Contexto();
        }

        public IEnumerable<Endereco> ListarTodos()
        {
            return _contexto.Enderecos
                .Include(x => x.Cidade)
                .ThenInclude(y => y.Estado)
                .ToList();
        }

        public Endereco BuscarPorId(int id)
        {
            return _contexto.Enderecos
                .Include(x => x.Cidade)
                .ThenInclude(y => y.Estado)
                .First(x => x.idEndereco == id);
        }

        public IEnumerable<Endereco> ListarPorIdCidade(int idCidade)
        {
            return _contexto.Enderecos
                .Where(x => x.Cidade.idCidade == idCidade)
                .ToList();
        }
    }
}
