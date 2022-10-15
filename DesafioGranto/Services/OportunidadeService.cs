using DesafioGranto.Models.Entities;
using DesafioGranto.Repositories.Interface;
using DesafioGranto.Services.Interface;
using System;
using System.Linq;

namespace DesafioGranto.Services
{
    public class OportunidadeService : IOportunidadeService
    {
        private readonly IOportunidadeRepository _oportunidadeRepository;
        private readonly IPublicaService _publicaService;
        
        public OportunidadeService(IOportunidadeRepository oportunidadeRepository, IPublicaService publicaService)
        {
            _oportunidadeRepository = oportunidadeRepository;
            _publicaService = publicaService;
        }

        public async Task Cadastrar(Oportunidade oportunidade)
        {
            var json = await _publicaService.ConsultarCnpj(oportunidade.Cnpj);
            oportunidade.RazaoSocial = (string?)json["razao_social"];
            oportunidade.DescricaoAtividade = (string?)json["estabelecimento"]["atividade_principal"]["descricao"];
            var codigoRegiao = ((string?)json["estabelecimento"]["estado"]["ibge_id"]).Substring(0, 1);
        }

        public Task<Oportunidade> BuscarOportunidadeUsuario(long id)
        {
            throw new NotImplementedException();
        }
    }
}
