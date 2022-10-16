using DesafioGranto.Services.Interface;
using Newtonsoft.Json.Linq;

namespace DesafioGranto.Services
{
    public class PublicaService : IPublicaService
    {
        public async Task<JObject> ConsultarCnpj(string cnpj)
        {
            using (var client = new HttpClient())
            {
                var uri = $"https://publica.cnpj.ws/cnpj/{cnpj}";
                var response = await client.GetAsync(uri);
                JObject json = JObject.Parse(response.Content.ReadAsStringAsync().Result);
                if (response.IsSuccessStatusCode)
                {
                    return json;
                }
                else
                {
                    throw new Exception((string?)json["detalhes"]);
                }
            }
        }
    }
}
