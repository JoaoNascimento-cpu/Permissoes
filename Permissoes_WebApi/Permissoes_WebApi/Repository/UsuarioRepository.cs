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
        public void AtualizarUsuario(int id, Usuario usuario)
        {
            Usuario usuarioBuscado = ctx.Usuarios.Find(id);

            if (usuario.Email != null)
            {
                usuarioBuscado.Email = usuario.Email;
                usuarioBuscado.Senha = usuario.Senha;
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
