using System.ComponentModel.DataAnnotations;

namespace DesafioGranto.Models.DTO
{
    public class OportunidadeCadastroDTO
    {
        [Required]
        [RegularExpression("[0-9]{2}\\.?[0-9]{3}\\.?[0-9]{3}\\/?[0-9]{4}\\-?[0-9]{2}", ErrorMessage = "Informe um CNPJ válido")]
        public string Cnpj { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public decimal ValorMonetario { get; set; }

    }
}
