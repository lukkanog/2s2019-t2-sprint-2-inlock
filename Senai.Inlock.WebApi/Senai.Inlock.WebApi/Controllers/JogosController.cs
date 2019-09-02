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
    [Authorize(Roles = "1")]
    [ApiController]
    public class JogosController : ControllerBase
    {
        JogoRepository jogoRepository = new JogoRepository();

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(jogoRepository.Listar());
        }

        [HttpPost]
        public IActionResult Cadastrar(Jogos jogo)
        {
            jogoRepository.Cadastrar(jogo);
            return Ok();
        }
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
    }

    }
