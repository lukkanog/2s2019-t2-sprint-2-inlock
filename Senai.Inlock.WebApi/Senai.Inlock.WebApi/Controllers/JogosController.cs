using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Inlock.WebApi.Domains;
using Senai.Inlock.WebApi.Repositories;

namespace Senai.Inlock.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class JogosController : ControllerBase
    {
        JogoRepository jogoRepository = new JogoRepository();

        [Authorize]
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(jogoRepository.Listar());
        }

        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Cadastrar(Jogos jogo)
        {
            jogoRepository.Cadastrar(jogo);
            return Ok();
        }

        [Authorize(Roles = "1")]
        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Jogos jogo)
        {
            jogo.JogoId = id;
            try
            {
                jogoRepository.Atualizar(jogo);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest();
            }
        }

        [Authorize(Roles = "1")]
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id) {
            try
            {
                jogoRepository.Deletar(id);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest();
            }
        }

        [Authorize]
        [HttpGet("maiscaros")]
        public IActionResult ListarMaisCaros()
        {
            return Ok(jogoRepository.ListarCincoMaisCaros());
        }

        [Authorize]
        [HttpGet("maisrecentes")]
        public IActionResult ListarMaisRecentes()
        {
            return Ok(jogoRepository.ListarMaisRecentes());
        }

        [Authorize]
        [HttpGet("datalancamento")]
        public IActionResult DataLancamento()
        {
            return Ok(jogoRepository.DataLancamento());
        }

        [Authorize]
        [HttpGet("buscar/{nome}")]
        public IActionResult BuscarPorNome(string nome)
        {
            var jogo = jogoRepository.BuscarJogoPorNome(nome);
            if (jogo == null)
                return NotFound();

            return Ok(jogo);
        }
    }

}
