using DesafioGranto.Models;
using DesafioGranto.Models.Entities;
using DesafioGranto.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

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

        public Task<List<Usuario>> FindByRegiaoOrderDataOportunidade(int regiao)
        {
            //var sql = "SELECT * FROM Usuario US " +
            //"LEFT JOIN Oportunidade OP ON OP.UsuarioId = US.Id " +
            //"ORDER BY OP.DataOportunidade DESC";
            //var teste = _context.Database.(sql);
            try
            {
                var x = _context.Usuario
                                .Include(u => u.Oportunidades)
                                .Where(u => u.Regiao == regiao)
                                .OrderByDescending(u => u.Oportunidades.Select(o => o.DataOportunidade).Max())
                                .ToListAsync();
                return x;
            } catch (Exception ex)
            {
                throw ex;
            }
            
            //return _context.Usuario.Include(u => u.Oportunidades).OrderBy(o => o.)
        }
    }
}
