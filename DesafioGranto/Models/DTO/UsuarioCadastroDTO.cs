using System.ComponentModel.DataAnnotations;

namespace DesafioGranto.Models.DTO
{
    public class UsuarioCadastroDTO
    {
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public int Regiao { get; set; }
    }
}
