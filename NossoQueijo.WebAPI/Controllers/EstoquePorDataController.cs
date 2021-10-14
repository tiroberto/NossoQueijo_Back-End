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
    public class EstoquePorDataController : ControllerBase
    {
        private readonly IEstoquePorDataAplicacao appEstoquePorData;

        public EstoquePorDataController(IEstoquePorDataAplicacao estoquePorDataAplicacao)
        {
            appEstoquePorData = estoquePorDataAplicacao;
        }

        [HttpGet("listar")]
        public IEnumerable<EstoquePorData> ListarTodos() => appEstoquePorData.ListarTodos();

        [HttpGet("buscar-um")]
        [EnableCors]
        public EstoquePorData BuscarPorId(int id) => appEstoquePorData.BuscarPorId(id);

        [HttpGet("listar-por-periodo")]
        public NotificationResult ListarPorPeriodo(DateTime inicio, DateTime fim) => appEstoquePorData.ListarPorPeriodo(inicio, fim);

        [HttpGet("listar-por-produto")]
        public IEnumerable<EstoquePorData> ListarPorIdProduto(int idProduto) => appEstoquePorData.ListaPorIdProduto(idProduto);

        [HttpPost("salvar")]
        public NotificationResult Salvar(EstoquePorData EstoquePorData) => appEstoquePorData.Salvar(EstoquePorData);

        [HttpDelete("excluir")]
        public NotificationResult Excluir(int id) => appEstoquePorData.Remover(id);
    }
}
