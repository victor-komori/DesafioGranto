﻿using DesafioGranto.Models;
using DesafioGranto.Models.Entities;
using DesafioGranto.Models.Enum;
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

        public Task<Usuario> FindByEmail(string email)
        {
            return _context.Usuario.Where(u => u.Email == email).FirstOrDefaultAsync();
        }

        public Task<List<Usuario>> FindByRegiaoOrderDataOportunidade(int regiao)
        {
            return _context.Usuario
                                .Include(u => u.Oportunidades)
                                .Where(u => u.Regiao == (Regiao)regiao)
                                .OrderByDescending(u => u.Oportunidades.Select(o => o.DataOportunidade).Max())
                                .ToListAsync();
        }
    }
}
