using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
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
    [ApiController]
    [Produces ("application/json")]
    public class EstudiosController : ControllerBase
    {
        EstudioRepositorio estudioRepositorio = new EstudioRepositorio();

        [Authorize]
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(estudioRepositorio.Listar());
        }

        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Cadastrar(Estudios estudio)
        {
            estudioRepositorio.Cadastrar(estudio);
            return Ok();
        }


        [Authorize(Roles = "1")]
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

        [Authorize(Roles = "1")]
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

        [Authorize]
        [HttpGet("jogos")]
        public IActionResult ListarEstudiosEJogos()
        {
            return Ok(estudioRepositorio.ListarEstudiosEJogos());
        }
        [HttpGet("estudiobuscar/{Nome}")]
        public IActionResult ListarEstudiosPorNome(string Nome)
        {
            if(Nome == null)
            {
                return BadRequest(new { Message = "Nome é nulo" });
            }
            return Ok(estudioRepositorio.ListarEstudiosPorNome(Nome));
        }


        [Authorize]
        [HttpGet("buscarporpais/{id}")]
        public IActionResult BuscarPorPais(int id)
        {
            return Ok(estudioRepositorio.ListarPorPais(id));
        }


        [Authorize]
        [HttpGet("buscarjogosporpais/{id}")]
        public IActionResult BuscarJogosPorPais(int id)
        {
            return Ok(estudioRepositorio.ListarTudoPorPais(id));
        }

        [Authorize(Roles = "1")]
        [HttpGet("listarporadm")]
        public IActionResult ListarPorAdministrador()
        {
            try
            {
                var usuario = HttpContext.User;

                var idUsuario = int.Parse(usuario.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Jti).Value);

                return Ok(estudioRepositorio.ListarPorAdministrador(idUsuario));
            }
            catch (Exception)
            {
                return BadRequest();
                
            }
        }

        [Authorize(Roles = "1")]
        [HttpGet("estudioseadms")]
        public IActionResult ListarEstudiosEAdms()
        {
            var lista = estudioRepositorio.ListarEstudiosEAdms();
            foreach (var item in lista)
            {
                item.Usuario.Senha = "xxxxx";
                item.Usuario.Estudios = null;
            }
            return Ok(lista);
        }

        [Authorize]
        [HttpGet("estudiosrecentes")]
        public IActionResult ListarEstudiosRecentes()
        {
            return Ok(estudioRepositorio.ListarEstudiosNovos());
        }
    }
}