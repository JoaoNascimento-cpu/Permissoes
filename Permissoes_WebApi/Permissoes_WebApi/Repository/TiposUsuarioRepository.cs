using Permissoes_WebApi.Contexts;
using Permissoes_WebApi.Domains;
using Permissoes_WebApi.Interface;
using System.Collections.Generic;
using System.Linq;

namespace Permissoes_WebApi.Repository
{
    public class TiposUsuarioRepository : ITiposUsuarioRepository
    {
        Permissoes ctx = new Permissoes();

        public void Atualizar(int id, TiposUsuario novoTiposUsuario)
        {
            TiposUsuario tipoUsuarioBuscado = ctx.TiposUsuarios.Find(id);

            if (tipoUsuarioBuscado.TituloTiposUsuario != null)
            {
                tipoUsuarioBuscado.TituloTiposUsuario = novoTiposUsuario.TituloTiposUsuario;
            }

            ctx.TiposUsuarios.Update(tipoUsuarioBuscado);
            ctx.SaveChanges();
        }

        public TiposUsuario BuscarPorId(int id)
        {
            return ctx.TiposUsuarios.FirstOrDefault(u => u.IdTiposUsuario == id);
        }

        public void Cadastrar(TiposUsuario novoTiposUsuario)
        {
            ctx.Add(novoTiposUsuario);
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            TiposUsuario tipoUsuarioBuscado = ctx.TiposUsuarios.Find(id);
            ctx.TiposUsuarios.Remove(tipoUsuarioBuscado);
            ctx.SaveChanges();
        }

        public List<TiposUsuario> Listar()
        {
            return ctx.TiposUsuarios.ToList();
        }
    }
}
