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
    [Authorize(Roles = "1")]
    [Route("api/[controller]")]
    [ApiController]
    [Produces ("application/json")]
    public class EstudiosController : ControllerBase
    {
        EstudioRepositorio estudioRepositorio = new EstudioRepositorio();
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(estudioRepositorio.Listar());
        }
        [HttpPost]
        public IActionResult Cadastrar(Estudios estudio)
        {
            estudioRepositorio.Cadastrar(estudio);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Estudios estudio)
        {
            estudio.EstudioId = id;
            try
            {
                estudioRepositorio.Atualizar(estudio);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { Mensagem = ex.Message});
            }
        }


        [HttpDelete("{id}")]
        public IActionResult Excluir(int id)
        {
            try
            {
                estudioRepositorio.Excluir(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { Mensagem = ex.Message });
            }
        }


        //[HttpGet("jogos")]
        //public IActionResult ListarEstudiosEJogos()
        //{
        //    return Ok(estudioRepositorio.ListarEstudiosEJogos());
        //}
    }
}