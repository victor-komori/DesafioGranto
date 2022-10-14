using DesafioGranto.Models.Entities;

namespace DesafioGranto.Repositories.Interface
{
    public interface IOportunidadeRepository
    {
        public Task<bool> Cadastrar(Oportunidade oportunidade);
        public Task<Oportunidade> BuscarOportunidadeUsuario(long id);
    }
}
