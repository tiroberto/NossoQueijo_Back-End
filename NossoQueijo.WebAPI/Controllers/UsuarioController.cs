using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NossoQueijo.Aplicacao;
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
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioAplicacao appUsuario;

        public UsuarioController(IUsuarioAplicacao usuarioAplicacao)
        {
            appUsuario = usuarioAplicacao;
        }

        [HttpGet("listar")]
        public IEnumerable<Usuario> ListarTodos() => appUsuario.ListarTodos();

        [HttpGet("listar-por-tipousuario")]
        public IEnumerable<Usuario> ListarPorIdTipoUsuario(int idTipoUsuario) => appUsuario.ListarPorIdTipoUsuario(idTipoUsuario);

        [HttpGet("verificar-login")]
        public NotificationResult VerificarLogin(string email, string senha) => appUsuario.VerificarLogin(email, senha);

        [HttpGet("buscar-um")]
        [EnableCors]
        public NotificationResult BuscarPorId(int id) => appUsuario.BuscarPorId(id);

        [HttpPost("salvar")]
        public NotificationResult Salvar(Usuario usuario) => appUsuario.Salvar(usuario);

        [HttpDelete("excluir-por-tipousuario")]
        public NotificationResult RemoverPorIdTipoUsuario(int idTipoUsuario) => appUsuario.RemoverPorIdTipoUsuario(idTipoUsuario);

        [HttpDelete("excluir")]
        public NotificationResult Remover(int id) => appUsuario.Remover(id);
    }
}
