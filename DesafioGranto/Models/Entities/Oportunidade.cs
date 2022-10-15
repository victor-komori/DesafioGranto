namespace DesafioGranto.Models.Entities
{
    public class Oportunidade
    {
        public int Id { get; set; }
        public string Cnpj { get; set; }
        public string Nome { get; set; }
        public decimal ValorMonetario { get; set; }
        public string? RazaoSocial { get; set; }
        public string? DescricaoAtividade { get; set; }
    }
}
