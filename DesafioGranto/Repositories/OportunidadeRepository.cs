using DesafioGranto.Models;
using DesafioGranto.Models.Entities;
using DesafioGranto.Repositories.Interface;

namespace DesafioGranto.Repositories
{
    public class OportunidadeRepository : IOportunidadeRepository
    {
        private readonly DesafioContext _context;
        public OportunidadeRepository(DesafioContext desafioContext)
        {
            _context = desafioContext;
        }
        public Task<Oportunidade> BuscarOportunidadeUsuario(long id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Cadastrar(Oportunidade oportunidade)
        {
            throw new NotImplementedException();
        }
    }
}
