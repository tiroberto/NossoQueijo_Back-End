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
    public class StatusController : ControllerBase
    {
        private readonly IStatusAplicacao appStatus;

        public StatusController(IStatusAplicacao StatusAplicacao)
        {
            appStatus = StatusAplicacao;
        }

        [HttpGet("listar")]
        public IEnumerable<Status> ListarTodos() => appStatus.ListarTodos();

        [HttpGet("buscar-um")]
        public Status BuscarPorId(int id) => appStatus.BuscarPorId(id);

        [HttpPost("salvar")]
        public NotificationResult Salvar(Status Status) => appStatus.Salvar(Status);

        [HttpDelete("excluir")]
        public NotificationResult Excluir(int id) => appStatus.Remover(id);
    }
}
