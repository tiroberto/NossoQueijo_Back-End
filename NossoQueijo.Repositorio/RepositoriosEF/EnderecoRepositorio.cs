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
                .Include(x => x.Usuario)
                .ToList();
        }
         
        public int AdicionarPersonalizado(Endereco endereco)
        {
            endereco.Cidade = _contexto.Cidades
                .Include(x => x.Estado)
                .Where(x => x.idCidade == endereco.Cidade.idCidade)
                .FirstOrDefault();
            endereco.Usuario = _contexto.Usuarios
                .Where(x => x.idUsuario == endereco.Usuario.idUsuario)
                .FirstOrDefault();
            _contexto.Enderecos.Add(endereco);
            _contexto.SaveChanges();

            return endereco.idEndereco;
        }

        public void AtualizarPersonalizado(Endereco endereco)
        {            
            endereco.Cidade = _contexto.Cidades
                .First(x => x.idCidade == endereco.Cidade.idCidade);
            endereco.Usuario = _contexto.Usuarios
                .First(x => x.idUsuario == endereco.Usuario.idUsuario);
            _contexto.Enderecos.Update(endereco);
            _contexto.SaveChanges();
        }

        public Endereco BuscarPorId(int id)
        {
            return _contexto.Enderecos
                .Include(x => x.Cidade)
                .ThenInclude(y => y.Estado)
                .Include(x => x.Usuario)
                .First(x => x.idEndereco == id);
        }

        public IEnumerable<Endereco> ListarPorIdCidade(int idCidade)
        {
            return _contexto.Enderecos
                .Include(x => x.Cidade)
                .ThenInclude(x => x.Estado)
                .Include(x => x.Usuario)
                .Where(x => x.Cidade.idCidade == idCidade)
                .ToList();
        }
    }
}
