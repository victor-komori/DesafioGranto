using DesafioGranto.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace DesafioGranto.Data
{
    public class DesafioContext : DbContext
    {
        public DesafioContext(DbContextOptions<DesafioContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>()
                .Property(u => u.Regiao)
                .HasConversion<int>();

            modelBuilder.Entity<Oportunidade>()
                .Property(b => b.ValorMonetario)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Oportunidade>()
                .HasOne(o => o.Usuario)
                .WithMany(u => u.Oportunidades)
                .HasForeignKey(o => o.UsuarioId);
        }

        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Oportunidade> Oportunidade { get; set; }
    }
}
