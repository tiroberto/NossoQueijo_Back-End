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
        public NotificationResult BuscarPorIdFichaProducao(int idFichaProducao) => appEstoquePorData.BuscarPorIdFichaProducao(idFichaProducao);

        [HttpGet("listar-por-periodo")]
        public NotificationResult ListarPorPeriodo(DateTime inicio, DateTime fim) => appEstoquePorData.ListarPorPeriodo(inicio, fim);

        [HttpGet("listar-por-produto")]
        public NotificationResult ListarPorIdProduto(int idProduto) => appEstoquePorData.ListaPorIdProduto(idProduto);

        [HttpPost("adicionar")]
        public NotificationResult Adicionar(EstoquePorData EstoquePorData) => appEstoquePorData.Adicionar(EstoquePorData);

        [HttpPost("atualizar")]
        public NotificationResult Atualizar(EstoquePorData EstoquePorData) => appEstoquePorData.Atualizar(EstoquePorData);

        [HttpDelete("excluir")]
        public NotificationResult Excluir(EstoquePorData estoquePorData) => appEstoquePorData.Remover(estoquePorData);
    }
}
