using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Permissoes_WebApi.Domains;
using Permissoes_WebApi.Interface;
using Permissoes_WebApi.Repository;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Permissoes_WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IUsuarioRepository usuario { get; set; }

        public LoginController()
        {
            usuario = new UsuarioRepository();
        }

        //http://localhost:5000/api/Login
        [HttpPost]
        public IActionResult Login(Usuario login)
        {
            //Busca o usuário pelo e-mail e senha
            Usuario usuarioBuscado = usuario.Login(login.Email, login.Senha);

            //caso não encontre nenhum usuário  irá retornar um status code Not Found
            if (usuarioBuscado == null)
            {
                return NotFound("E-mail ou senha invalidos");
            }

            //caso encontre prossegue a criação do token
            //Define os dados que serão fornecidos no Token - Payload
            var claims = new[]
            {
                // Armazena na Claim o e-mail do usuário autenticado
                    new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Email, usuarioBuscado.Email),

                    // Armazena na Claim o ID do usuário autenticado
                    new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Jti, usuarioBuscado.IdUsuario.ToString()),

                    // Armazena na Claim o tipo de usuário que foi autenticado (Administrador ou Comum)
                    new Claim(ClaimTypes.Role, usuarioBuscado.IdTiposUsuario.ToString()),

                    // Armazena na Claim o tipo de usuário que foi autenticado (Administrador ou Comum) de forma personalizada
                    new Claim("role", usuarioBuscado.IdTiposUsuario.ToString()),

                    // Armazena na Claim o nome do usuário que foi autenticado
                    new Claim(JwtRegisteredClaimNames.Name, usuarioBuscado.Nome)
            };

            //chave de acesso ao Token
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("Permissoes-Usuario-autenticação"));

            //Define as credenciais do token- Header
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            //gera token
            var token = new JwtSecurityToken
                (
                    issuer: "Permissoes.WebApi",      //definindo o emissor do token
                    audience: "Permissoes.WebApi",      //destinatário do token
                    claims: claims,               //dados definidos na linha 47
                    expires: DateTime.Now.AddMinutes(30), //tempo de expiração
                    signingCredentials: cred           //credenciais do token    
                );

            //retorna um Status code - 200(OK)

            return Ok
                (
                    new
                    {
                        token = new JwtSecurityTokenHandler().WriteToken(token)
                    }
                );
        }
    }
}
