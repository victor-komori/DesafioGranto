using DesafioGranto.Models;
using DesafioGranto.Models.Entities;
using DesafioGranto.Repositories;
using DesafioGranto.Repositories.Interface;
using DesafioGranto.Services.Interface;
using Newtonsoft.Json.Linq;

namespace DesafioGranto.Services
{
    public class OportunidadeService : IOportunidadeService
    {
        private readonly IOportunidadeRepository _oportunidadeRepository;
        private readonly IUsuarioRepository _usuarioRepository;
        
        public OportunidadeService(IOportunidadeRepository oportunidadeRepository, IUsuarioRepository usuarioRepository)
        {
            _oportunidadeRepository = oportunidadeRepository;
            _usuarioRepository = usuarioRepository;
        }

        public async Task Cadastrar(Oportunidade oportunidade, JObject json)
        {
            oportunidade.RazaoSocial = (string?)json["razao_social"];
            oportunidade.DescricaoAtividade = (string?)json["estabelecimento"]["atividade_principal"]["descricao"];
            var ibgeId = ((string?)json["estabelecimento"]["estado"]["ibge_id"]);
            var regiao = Int32.Parse(ibgeId.Substring(0, 1));
            
            var listUsuario = await _usuarioRepository.FindByRegiaoOrderDataOportunidade(regiao);
            if (!listUsuario.Any())
            {
                throw new Exception($"Não foi encontrado vendedor na região {(Regiao)regiao} para essa oportunidade.");
            }

            var quantidadeUsuarios = listUsuario.Count;
            if (quantidadeUsuarios == 1)
            {
                var usuarioId = listUsuario.Select(u => u.Id).First();
                oportunidade.UsuarioId = usuarioId;
                _oportunidadeRepository.Cadastrar(oportunidade);
            } else
            {
                if (listUsuario.First().Oportunidades is not null)
                {
                    listUsuario.Remove(listUsuario.First());
                    quantidadeUsuarios -= 1;
                }
                var index = new Random().Next(quantidadeUsuarios);
                oportunidade.UsuarioId = listUsuario[index].Id;
                _oportunidadeRepository.Cadastrar(oportunidade);
            }
        }

        public Task<Oportunidade> BuscarOportunidadeUsuario(long id)
        {
            throw new NotImplementedException();
        }
    }
}
