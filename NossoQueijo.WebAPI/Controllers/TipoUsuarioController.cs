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
    public class TipoUsuarioController : ControllerBase
    {
        private readonly ITipoUsuarioAplicacao appTipoUsuario;

        public TipoUsuarioController(ITipoUsuarioAplicacao TipoUsuarioAplicacao)
        {
            appTipoUsuario = TipoUsuarioAplicacao;
        }

        [HttpGet("listar")]
        public IEnumerable<TipoUsuario> ListarTodos() => appTipoUsuario.ListarTodos();

        [HttpGet("buscar-um")]
        public NotificationResult BuscarPorId(int id) => appTipoUsuario.BuscarPorId(id);

        [HttpPost("salvar")]
        public NotificationResult Salvar(TipoUsuario TipoUsuario) => appTipoUsuario.Salvar(TipoUsuario);

        [HttpDelete("excluir")]
        public NotificationResult Excluir(int id) => appTipoUsuario.Remover(id);
    }
}
