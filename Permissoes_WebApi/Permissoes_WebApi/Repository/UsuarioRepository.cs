using Permissoes_WebApi.Contexts;
using Permissoes_WebApi.Domains;
using Permissoes_WebApi.Interface;
using System.Collections.Generic;
using System.Linq;

namespace Permissoes_WebApi.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        Permissoes ctx = new Permissoes();

        public void AtualizarUsuario(int id, Usuario novoUsuario)
        {
            Usuario usuarioBuscado = ctx.Usuarios.Find(id);

            if (novoUsuario.Email != null)
            {
                usuarioBuscado.Email = novoUsuario.Email;
                usuarioBuscado.Senha = novoUsuario.Senha;
                usuarioBuscado.Nome = novoUsuario.Nome; 
                usuarioBuscado.Idstatus = novoUsuario.Idstatus;
            }

            ctx.Usuarios.Update(usuarioBuscado);
            ctx.SaveChanges();
        }
    

        public Usuario BuscarPorId(int id)
        {
            return ctx.Usuarios.FirstOrDefault(u => u.IdUsuario == id);
        }

        public void Cadastro(Usuario NovoUsuario)
        {
            ctx.Add(NovoUsuario);
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            Usuario usuarioBuscado = ctx.Usuarios.Find(id);
            ctx.Usuarios.Remove(usuarioBuscado);
            ctx.SaveChanges();
        }

        public List<Usuario> Listar()
        {
            return ctx.Usuarios.ToList();
        }

        public Usuario Login(string email, string senha)
        {
            return ctx.Usuarios.FirstOrDefault(u => u.Email == email && u.Senha == senha);
        }
    }
}
