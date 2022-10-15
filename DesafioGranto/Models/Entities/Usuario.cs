using System.ComponentModel.DataAnnotations;

namespace DesafioGranto.Models.Entities
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public Regiao Regiao { get; set; }
        public List<Oportunidade> Oportunidades { get; set; }
    }
}