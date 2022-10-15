using Newtonsoft.Json.Linq;

namespace DesafioGranto.Services.Interface
{
    public interface IPublicaService
    {
        public Task<JObject> ConsultarCnpj(string cnpj);
    }
}
