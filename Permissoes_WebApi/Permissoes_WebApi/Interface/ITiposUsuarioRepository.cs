using Permissoes_WebApi.Domains;
using System.Collections.Generic;

namespace Permissoes_WebApi.Interface
{
    public interface ITiposUsuarioRepository
    {
        /// <summary>
        /// Método utilizado para a listagem dos tipos de usuários
        /// </summary>
        /// <returns>Lista de todos os tipos de usuários</returns>
        List<TiposUsuario> Listar();

        /// <summary>
        /// Método utilizado para buscar por um tipo de usuário através de seu id
        /// </summary>
        /// <param name="id">objeto que armazena o id do tipo de usuário</param>
        /// <returns>Retorna o tipo de usuário buscado</returns>
        TiposUsuario BuscarPorId(int id);

        /// <summary>
        /// Método utilizado para o cadastro de um novo tipo de usuário
        /// </summary>
        /// <param name="novoTiposUsuario">objeto que armazena as informações passando pelo corpo da requisição</param>
        void Cadastrar(TiposUsuario novoTiposUsuario);

        /// <summary>
        /// Deleta um tipo de usuário
        /// </summary>
        /// <param name="id">objeto que armazena o id do usuário que será deletado passando pela URL da requisição</param>
        void Deletar(int id);

        /// <summary>
        /// Atualiza um tipo de usuário já existente
        /// </summary>
        /// <param name="id">armazena o id do tipo de usuário que será atualizado através da URL da requisição</param>
        /// <param name="novoTiposUsuario">armazena novas informações para o tipo de usuário que está sendo atualizando passando as informações pelo corpo da requisição</param>
        void Atualizar(int id, TiposUsuario novoTiposUsuario);


    }
}
