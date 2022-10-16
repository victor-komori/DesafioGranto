namespace DesafioGranto.Models.DTO
{
    public class UsuarioDTO
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Regiao { get; set; }
        public List<OportunidadeDTO> Oportunidades { get; set; }
    }
}
