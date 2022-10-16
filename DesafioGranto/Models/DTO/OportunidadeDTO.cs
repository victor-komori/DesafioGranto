namespace DesafioGranto.Models.DTO
{
    public class OportunidadeDTO
    {
        public string Cnpj { get; set; }
        public string Nome { get; set; }
        public decimal ValorMonetario { get; set; }
        public string? RazaoSocial { get; set; }
        public string? DescricaoAtividade { get; set; }
        public DateTime DataOportunidade { get; set; }

    }
}
