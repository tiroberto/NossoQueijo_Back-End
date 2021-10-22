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
    public class CidadeController : ControllerBase
    {
        private readonly ICidadeAplicacao appCidade;

        public CidadeController(ICidadeAplicacao cidadeAplicacao)
        {
            appCidade = cidadeAplicacao;
        }

        [HttpGet("listar")]
        public IEnumerable<Cidade> ListarTodos() => appCidade.ListarTodos();

        [HttpGet("listar-por-estado")]
        public IEnumerable<Cidade> ListarPorIdEstado(int idEstado) => appCidade.ListarPorIdEstado(idEstado);

        [HttpGet("buscar-um")]
        [EnableCors]
        public NotificationResult BuscarPorId(int id) => appCidade.BuscarPorId(id);

        [HttpPost("salvar")]
        public NotificationResult Salvar(Cidade cidade) => appCidade.Salvar(cidade);        

        [HttpDelete("excluir")]
        public NotificationResult Excluir(int id) => appCidade.Remover(id);
    }
}
