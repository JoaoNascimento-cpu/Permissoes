using Permissoes_WebApi.Domains;
using System.Collections.Generic;

namespace Permissoes_WebApi.Interface
{
    public interface IStatusRepository
    {
        List<Status> Listar();

        /// <summary>
        /// método utilizado para buscr um usuário existente
        /// </summary>
        /// <param name="id">id do usuário que irá passar pela url da requisição</param>
        /// <returns>usuário buscado</returns>
        Status BuscarPorId(int id);

        /// <summary>
        /// método utilizado para cadastrar um novo usuário
        /// </summary>
        /// <param name="NovoUsuario">objeto que irá armazenar as informações do novo usuário cadastrado</param>
        void Cadastro(Status novoStatus);

        void Deletar(int id);

        /// <summary>
        /// método utilizado para atualizar determinado usuário
        /// </summary>
        /// <param name="id">id do usuário buscado</param>
        /// <param name="usuario">objeto que irá armazenar as novas informações do usuário</param>
        void AtualizarStatus(int id, Status novoStatus);
    }
}
