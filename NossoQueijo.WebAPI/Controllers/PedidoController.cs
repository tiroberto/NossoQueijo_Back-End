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
    public class PedidoController : ControllerBase
    {
        private readonly IPedidoAplicacao appPedido;

        public PedidoController(IPedidoAplicacao PedidoAplicacao)
        {
            appPedido = PedidoAplicacao;
        }

        [HttpGet("listar-paginado")]
        public IEnumerable<Pedido> ListarTodosPaginado(int pagina) => appPedido.ListarTodosPaginado(pagina);
        [HttpGet("listar")]
        public IEnumerable<Pedido> ListarTodos() => appPedido.ListarTodos();

        [HttpGet("listar-por-periodo")]
        public NotificationResult ListarPorPeriodo(DateTime inicio, DateTime fim, int pagina) => appPedido.ListarPorPeriodoPaginado(inicio, fim, pagina);

        [HttpGet("listar-por-usuario")]
        public NotificationResult ListarPorIdUsuario(int idUsuario, int pagina) => appPedido.ListarPorIdUsuarioPaginado(idUsuario, pagina);

        [HttpGet("listar-por-status")]
        public NotificationResult ListarPorIdStatus(int idStatus, int pagina) => appPedido.ListarPorIdStatusPaginado(idStatus, pagina);

        [HttpGet("listar-por-formapagamento")]
        public NotificationResult ListarPorIdFormaPagamento(int idFormaPagamento, int pagina) => appPedido.ListarPorIdFormaPagamentoPaginado(idFormaPagamento, pagina);

        [HttpGet("buscar-um")]
        [EnableCors]
        public NotificationResult BuscarPorId(int id) => appPedido.BuscarPorId(id);

        [HttpPost("salvar")]
        public NotificationResult Salvar(Pedido Pedido) => appPedido.Salvar(Pedido);

        [HttpDelete("excluir")]
        public NotificationResult Excluir(int id) => appPedido.Remover(id);
    }
}
