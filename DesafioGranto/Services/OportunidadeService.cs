using DesafioGranto.Models.Entities;
using DesafioGranto.Repositories.Interface;
using DesafioGranto.Services.Interface;

namespace DesafioGranto.Services
{
    public class OportunidadeService : IOportunidadeService
    {
        private readonly IOportunidadeRepository _oportunidadeRepository;
        

        public OportunidadeService(IOportunidadeRepository oportunidadeRepository)
        {
            _oportunidadeRepository = oportunidadeRepository;
        }

        public async void Cadastrar(Oportunidade oportunidade)
        {
            var uri = $"https://publica.cnpj.ws/cnpj/{oportunidade.Cnpj}";

            HttpClient client = new HttpClient();
            //client.BaseAddress = new Uri(uri);
            //client.DefaultRequestHeaders.Accept.Clear();

            var response = await client.GetStringAsync(uri);

            throw new NotImplementedException();
        }

        public Task<Oportunidade> BuscarOportunidadeUsuario(long id)
        {
            throw new NotImplementedException();
        }
    }
}
