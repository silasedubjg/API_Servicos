namespace API_Servicos.Repositorios.Interfaces
{
    public interface IUsuarioRepositorio
    {
        Task<List<Models.UsuarioModel>> BuscarTodosUsuarios();

        Task<Models.UsuarioModel> BuscarUsuarioPorId(int id);

        Task<Models.UsuarioModel> AdicionarUsuario(Models.UsuarioModel usuario);

        Task<Models.UsuarioModel> AtualizarUsuario(Models.UsuarioModel usuario, int id);

        Task<Models.UsuarioModel> DeletarUsuario(int id);
    }
}
