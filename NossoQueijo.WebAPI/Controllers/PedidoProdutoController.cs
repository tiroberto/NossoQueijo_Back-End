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
    public class PedidoProdutoController : ControllerBase
    {
        private readonly IPedidoProdutoAplicacao appPedidoProduto;

        public PedidoProdutoController(IPedidoProdutoAplicacao pedidoProdutoAplicacao)
        {
            appPedidoProduto = pedidoProdutoAplicacao;
        }

        [HttpGet("listar")]
        public IEnumerable<PedidoProduto> ListarTodos() => appPedidoProduto.ListarTodos();

        [HttpGet("listar-por-pedido")]
        public IEnumerable<PedidoProduto> ListarPorIdPedido(int idPedido) => appPedidoProduto.ListarPorIdPedido(idPedido);

        //[HttpPost("salvar")]
        //public NotificationResult Salvar(PedidoProduto PedidoProduto) => appPedidoProduto.Salvar(PedidoProduto);

        [HttpDelete("excluir")]
        public NotificationResult Excluir(int idPedido, int idProduto) => appPedidoProduto.Remover(idPedido, idProduto);
    }
}
