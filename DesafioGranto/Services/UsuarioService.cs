using DesafioGranto.Models.Entities;
using DesafioGranto.Repositories.Interface;
using DesafioGranto.Services.Interface;

namespace DesafioGranto.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public void Cadastrar(Usuario usuario)
        {
            
            _usuarioRepository.Cadastrar(usuario);
        }

        public Task<Usuario> FindByEmail(string email)
        {
            return _usuarioRepository.FindByEmail(email);
        }
    }
}
