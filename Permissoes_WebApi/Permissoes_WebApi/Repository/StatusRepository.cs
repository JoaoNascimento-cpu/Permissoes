using Permissoes_WebApi.Contexts;
using Permissoes_WebApi.Domains;
using Permissoes_WebApi.Interface;
using System.Collections.Generic;
using System.Linq;

namespace Permissoes_WebApi.Repository
{
    public class StatusRepository : IStatusRepository
    {
        Permissoes ctx = new Permissoes();

        public void AtualizarStatus(int id, Status novoStatus)
        {
            Status statusBuscado = ctx.Statuses.Find(id);

            if (novoStatus.TituloStatus != null)
            {
                statusBuscado.TituloStatus = novoStatus.TituloStatus;
            }

            ctx.Statuses.Update(statusBuscado);
            ctx.SaveChanges();
        }

        public Status BuscarPorId(int id)
        {
            return ctx.Statuses.FirstOrDefault(u => u.IdStatus == id);
        }

        public void Cadastro(Status novoStatus)
        {
            ctx.Add(novoStatus);
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            Status statusBuscado = ctx.Statuses.Find(id);
            ctx.Statuses.Remove(statusBuscado);
            ctx.SaveChanges();
        }

        public List<Status> Listar()
        {
            return ctx.Statuses.ToList();
        }
    }
}
