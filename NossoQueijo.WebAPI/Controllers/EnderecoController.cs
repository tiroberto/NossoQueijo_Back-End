using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NossoQueijo.Comum.NotificationPattern;
using NossoQueijo.Dominio.Entidades;
using NossoQueijo.Dominio.Interfaces.Aplicacao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NossoQueijo.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnderecoController : ControllerBase
    {
        private readonly IEnderecoAplicacao appEndereco;

        public EnderecoController(IEnderecoAplicacao enderecoAplicacao)
        {
            appEndereco = enderecoAplicacao;
        }

        [HttpGet("listar")]
        public IEnumerable<Endereco> ListarTodos() => appEndereco.ListarTodos();

        [HttpGet("listar-por-cidade")]
        public IEnumerable<Endereco> ListarPorIdCidade(int idCidade) => appEndereco.ListarPorIdCidade(idCidade);

        [HttpGet("buscar-um")]
        [EnableCors]
        public Endereco BuscarPorId(int id) => appEndereco.BuscarPorId(id);

        [HttpPost("salvar")]
        public NotificationResult Salvar(Endereco endereco) => appEndereco.Salvar(endereco);

        [HttpDelete("excluir")]
        public NotificationResult Excluir(int id) => appEndereco.Remover(id);
    }
}
