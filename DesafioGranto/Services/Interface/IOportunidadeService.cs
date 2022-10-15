using DesafioGranto.Models.Entities;
using Newtonsoft.Json.Linq;

namespace DesafioGranto.Services.Interface
{
    public interface IOportunidadeService
    {
        public Task Cadastrar(Oportunidade oportunidade, JObject json);
    }
}
