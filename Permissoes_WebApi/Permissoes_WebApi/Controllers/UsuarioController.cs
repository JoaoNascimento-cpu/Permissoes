using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Permissoes_WebApi.Domains;
using Permissoes_WebApi.Interface;
using Permissoes_WebApi.Repository;
using System;

namespace Permissoes_WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private IUsuarioRepository usuario { get; set; }

        public UsuarioController()
        {
            usuario = new UsuarioRepository();
        }

        [HttpGet]
        //http://localhost:5000/api/Usuario
        public IActionResult Listar()
        {
            try
            {
                return Ok(usuario.Listar());
            }
            catch (Exception exception)
            {

                return BadRequest(exception);
            }
        }

        [HttpGet("{id}")]
        //http://5000/api/usuario
        public IActionResult BuscarPorId(int id)
        {
            try
            {
                return Ok(usuario.BuscarPorId(id));
            }
            catch (Exception excepition)
            {
                return BadRequest(excepition);
            }
        }

        
        [Authorize(Roles = "1" + "," + "2")]
        [HttpPost]
        public IActionResult Cadastro(Usuario novoUsuario)
        {
            try
            {
                usuario.Cadastro(novoUsuario);
                return StatusCode(201);
            }
            catch (Exception exception)
            {

                return BadRequest(exception);
            }
        }

        [Authorize(Roles = "2")]
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            try
            {
                usuario.Deletar(id);
                return StatusCode(204);
            }
            catch (Exception exception)
            {

                return BadRequest(exception);
            }
        }

        [Authorize(Roles = "1" + "," + "2")]
        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Usuario novoUsuario)
        {
            try
            {
                usuario.AtualizarUsuario(id, novoUsuario);
                return StatusCode(204);
            }
            catch (Exception exception)
            {
                return BadRequest(exception);
            }
        }

    }
}
