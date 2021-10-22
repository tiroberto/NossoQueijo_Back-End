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
    public class FormaPagamentoController : ControllerBase
    {
        private readonly IFormaPagamentoAplicacao appFormaPagamento;

        public FormaPagamentoController(IFormaPagamentoAplicacao FormaPagamentoAplicacao)
        {
            appFormaPagamento = FormaPagamentoAplicacao;
        }

        [HttpGet("listar")]
        public IEnumerable<FormaPagamento> ListarTodos() => appFormaPagamento.ListarTodos();

        [HttpGet("buscar-um")]
        [EnableCors]
        public NotificationResult BuscarPorId(int id) => appFormaPagamento.BuscarPorId(id);

        [HttpPost("salvar")]
        public NotificationResult Salvar(FormaPagamento FormaPagamento) => appFormaPagamento.Salvar(FormaPagamento);

        [HttpDelete("excluir")]
        public NotificationResult Excluir(int id) => appFormaPagamento.Remover(id);
    }
}
