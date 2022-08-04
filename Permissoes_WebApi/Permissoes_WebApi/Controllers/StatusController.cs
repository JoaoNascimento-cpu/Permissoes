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
    public class StatusController : ControllerBase
    {
        private IStatusRepository status { get; set; }

        public StatusController()
        {
            status = new StatusRepository();
        }

        [HttpGet]
        //http://localhost:5000/api/Usuario
        public IActionResult Listar()
        {
            try
            {
                return Ok(status.Listar());
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
                return Ok(status.BuscarPorId(id));
            }
            catch (Exception excepition)
            {
                return BadRequest(excepition);
            }
        }

        //[Authorize(Roles = "2")]
        [HttpPost]
        public IActionResult Cadastro(Status novoStatus)
        {
            try
            {
                status.Cadastro(novoStatus);
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
                status.Deletar(id);
                return StatusCode(204);
            }
            catch (Exception exception)
            {

                return BadRequest(exception);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Status novoStatus)
        {
            try
            {
                status.AtualizarStatus(id, novoStatus);
                return StatusCode(204);
            }
            catch (Exception exception)
            {
                return BadRequest(exception);
            }
        }

    }
}
