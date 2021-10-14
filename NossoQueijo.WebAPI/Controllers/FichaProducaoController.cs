﻿using Microsoft.AspNetCore.Cors;
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
        [EnableCors]
        public FichaProducao BuscarPorId(int id) => appFichaProducao.BuscarPorId(id);

        [HttpGet("listar-por-periodo")]
        public NotificationResult ListarPorPeriodo(DateTime inicio, DateTime fim) => appFichaProducao.ListarPorPeriodo(inicio, fim);

        [HttpGet("listar-por-usuario")]
        public IEnumerable<FichaProducao> ListarPorIdUsuario(int idUsuario) => appFichaProducao.ListarPorIdUsuario(idUsuario);

        [HttpPost("salvar")]
        public NotificationResult Salvar(FichaProducao FichaProducao) => appFichaProducao.Salvar(FichaProducao);

        [HttpDelete("excluir")]
        public NotificationResult Excluir(int id) => appFichaProducao.Remover(id);
    }
}
