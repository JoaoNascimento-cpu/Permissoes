using Permissoes_WebApi.Domains;
using System.Collections.Generic;

namespace Permissoes_WebApi.Interface
{
    public interface IStatusRepository
    {
        List<Status> Listar();

        /// <summary>
        /// método utilizado para buscar um status existente
        /// </summary>
        /// <param name="id">id do status que irá passar pela url da requisição</param>
        /// <returns>usuário buscado</returns>
        Status BuscarPorId(int id);

        /// <summary>
        /// método utilizado para cadastrar um novo status
        /// </summary>
        /// <param name="novoStatus">objeto que irá armazenar as informações do novo status cadastrado</param>
        void Cadastro(Status novoStatus);

        void Deletar(int id);

        /// <summary>
        /// método utilizado para atualizar determinado status
        /// </summary>
        /// <param name="id">id do status buscado</param>
        /// <param name="novoStatus">objeto que irá armazenar as novas informações do status</param>
        void AtualizarStatus(int id, Status novoStatus);
    }
}
