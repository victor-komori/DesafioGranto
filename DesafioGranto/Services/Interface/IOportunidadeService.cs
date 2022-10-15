using DesafioGranto.Models.Entities;

namespace DesafioGranto.Services.Interface
{
    public interface IOportunidadeService
    {
        public Task Cadastrar(Oportunidade oportunidade);
        public Task<Oportunidade> BuscarOportunidadeUsuario(long id);
    }
}
