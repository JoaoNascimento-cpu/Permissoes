using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Permissoes_WebApi.Domains;
using Permissoes_WebApi.Interface;
using Permissoes_WebApi.Repository;
using System;

namespace Permissoes_WebApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class TiposUsuarioController : ControllerBase
    {
        private ITiposUsuarioRepository tipoUsuario { get; set; }

        public TiposUsuarioController()
        {
            tipoUsuario = new TiposUsuarioRepository();
        }

        [HttpGet]
        //http://localhost:5000/api/TiposUsuario
        public IActionResult Listar()
        {
            try
            {
                return Ok(tipoUsuario.Listar());
            }
            catch (Exception exception)
            {

                return BadRequest(exception);
            }
        }

        [HttpPost]
        public IActionResult Cadastro(TiposUsuario novoTipoUsuario)
        {
            try
            {
                tipoUsuario.Cadastrar(novoTipoUsuario);
                return StatusCode(201);
            }
            catch (Exception exception)
            {

                return BadRequest(exception);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            try
            {
                tipoUsuario.Deletar(id);
                return StatusCode(204);
            }
            catch (Exception exception)
            {

                return BadRequest(exception);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, TiposUsuario novoUsuario)
        {
            try
            {
                tipoUsuario.Atualizar(id, novoUsuario);
                return StatusCode(204);
            }
            catch (Exception exception)
            {
                return BadRequest(exception);
            }
        }
    }
}
