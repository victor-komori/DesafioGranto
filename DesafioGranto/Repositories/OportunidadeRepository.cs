using DesafioGranto.Data;
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

        public void Cadastrar(Oportunidade oportunidade)
        {
            _context.Add(oportunidade);
            _context.SaveChanges();
        }
    }
}
