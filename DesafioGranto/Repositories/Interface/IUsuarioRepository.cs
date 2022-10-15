using DesafioGranto.Models.Entities;

namespace DesafioGranto.Repositories.Interface
{
    public interface IUsuarioRepository
    {
        public void Cadastrar(Usuario usuario);
        public Task<Usuario> FindById(string email);
        public Task<List<Usuario>> FindByRegiaoOrderDataOportunidade(int regiao);
    }
}
