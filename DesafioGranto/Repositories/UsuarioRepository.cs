using DesafioGranto.Models;
using DesafioGranto.Models.Entities;
using DesafioGranto.Repositories.Interface;

namespace DesafioGranto.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly DesafioContext _context;
        public UsuarioRepository(DesafioContext desafioContext)
        {
            _context = desafioContext;
        }

        public void Cadastrar(Usuario usuario)
        {
            _context.Add(usuario);
            _context.SaveChanges();
        }

        public async Task<Usuario> FindById(string email)
        {
            return _context.Usuario.Where(u => u.Email == email).FirstOrDefault();
        }
    }
}
