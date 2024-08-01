

using API_Servicos.Data;
using API_Servicos.Models;
using API_Servicos.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API_Servicos.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio

 
    {
        private readonly SistemaDeTarefasDBContext _dbContext;

        public UsuarioRepositorio(SistemaDeTarefasDBContext sistemaDeTarefasDBContext)
        {
        _dbContext = sistemaDeTarefasDBContext;
        }
        public async Task<UsuarioModel> AdicionarUsuario(UsuarioModel usuario)
        {
            if (usuario is null)
            {
                throw new ArgumentNullException(nameof(usuario));
            }else
            {
                _dbContext.Usuarios.Add(usuario);
                _dbContext.SaveChanges();

                return usuario;
            }
            
        }

        public async Task<UsuarioModel> AtualizarUsuario(UsuarioModel usuario, int id)
        {
            UsuarioModel usuarui = await BuscarUsuarioPorId(id);

            if(usuarui is null)
            {
                throw new ArgumentNullException("Usuário não encontrado");

            }

            usuarui.Name = usuario.Name;
            usuarui.Email = usuario.Email;  
            
            _dbContext.Usuarios.Update(usuarui);
            _dbContext.SaveChanges();


            return usuario;


        }

        public async Task<List<UsuarioModel>> BuscarTodosUsuarios()
        {
            return await _dbContext.Usuarios.ToListAsync();
        }

        public async Task<UsuarioModel> BuscarUsuarioPorId(int id)
        {
           return await _dbContext.Usuarios.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<bool> DeletarUsuario(UsuarioModel usuario, int id)
        {
            UsuarioModel usuarui = await BuscarUsuarioPorId(id);

            if (usuarui is null)
            {
                throw new ArgumentNullException("Usuário não encontrado");

            }

            usuarui.Name = usuario.Name;
            usuarui.Email = usuario.Email;

            _dbContext.Usuarios.Remove(usuarui);
            _dbContext.SaveChanges();

            return true;
        }

        Task<UsuarioModel> IUsuarioRepositorio.AtualizarUsuario(UsuarioModel usuario, int id)
        {
            throw new NotImplementedException();
        }
    }
}
