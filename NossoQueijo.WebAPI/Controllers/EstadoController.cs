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
    public class EstadoController : ControllerBase
    {
        private readonly IEstadoAplicacao appEstado;

        public EstadoController(IEstadoAplicacao estadoAplicacao)
        {
            appEstado = estadoAplicacao;
        }

        [HttpGet("listar")]
        public IEnumerable<Estado> ListarTodos() => appEstado.ListarTodos();

        [HttpGet("buscar-um")]
        [EnableCors]
        public Estado BuscarPorId(int id) => appEstado.BuscarPorId(id);

        [HttpPost("salvar")]
        public NotificationResult Salvar(Estado Estado) => appEstado.Salvar(Estado);

        [HttpDelete("excluir")]
        public NotificationResult Excluir(int id) => appEstado.Remover(id);
    }
}
