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
    [EnableCors]
    [Route("api/[controller]")]
    [ApiController]
    public class FichaProducaoController : ControllerBase
    {
        private readonly IFichaProducaoAplicacao appFichaProducao;

        public FichaProducaoController(IFichaProducaoAplicacao fichaProducaoAplicacao)
        {
            appFichaProducao = fichaProducaoAplicacao;
        }

        [HttpGet("listar")]
        public IEnumerable<FichaProducao> ListarTodos() => appFichaProducao.ListarTodos();

        [HttpGet("buscar-um")]
        public NotificationResult BuscarPorId(int id) => appFichaProducao.BuscarPorId(id);

        [HttpGet("listar-por-periodo")]
        public NotificationResult ListarPorPeriodo(DateTime inicio, DateTime fim, int pagina) => appFichaProducao.ListarPorPeriodoPaginado(inicio, fim, pagina);

        [HttpGet("listar-por-usuario")]
        public NotificationResult ListarPorIdUsuarioPaginado(int idUsuario, int pagina) => appFichaProducao.ListarPorIdUsuarioPaginado(idUsuario, pagina);

        [HttpPost("salvar")]
        public NotificationResult Salvar(FichaProducao fichaProducao) => appFichaProducao.Salvar(fichaProducao);

        [HttpDelete("excluir")]
        public NotificationResult Excluir(int id) => appFichaProducao.Remover(id);
    }
}
