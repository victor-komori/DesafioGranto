using DesafioGranto.Models.DTO;
using DesafioGranto.Models.Entities;

namespace DesafioGranto.Services.Interface
{
    public interface IUsuarioService
    {
        public void Cadastrar(Usuario usuario);
        public Task<Usuario> FindByEmail(string email);
    }
}
