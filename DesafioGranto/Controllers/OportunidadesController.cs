using AutoMapper;
using DesafioGranto.Models.DTO;
using DesafioGranto.Models.Entities;
using DesafioGranto.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace DesafioGranto.Controllers
{
    [Route("core/oportunidade")]
    [ApiController]
    public class OportunidadesController : ControllerBase
    {
        private readonly IOportunidadeService _oportunidadeService;
        private readonly IPublicaService _publicaService;
        private readonly IMapper _mapper;

        public OportunidadesController(IOportunidadeService oportunidadeService, IPublicaService publicaService, IMapper mapper)
        {
            _oportunidadeService = oportunidadeService;
            _publicaService = publicaService;
            _mapper = mapper;
        }

        /// <summary>
        /// Cadastra uma nova oportunidade.
        /// </summary>
        /// <param name="oportunidadeCadastro">Json com os dados para cadastrar uma oportunidade</param>
        /// <response code="201">Oportunidade cadastrada com sucesso</response>
        /// <response code="400">Cnpj inválido</response>
        /// <response code="500">Erro interno do servidor</response>
        [HttpPost]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CadastroOportunidade(OportunidadeCadastroDTO oportunidadeCadastro)
        {
            try
            {
                var oportunidade = _mapper.Map<Oportunidade>(oportunidadeCadastro);
                oportunidade.DataOportunidade = DateTime.Now;

                var json = await _publicaService.ConsultarCnpj(oportunidade.Cnpj);

                oportunidade.RazaoSocial = (string?)json["razao_social"];
                oportunidade.DescricaoAtividade = (string?)json["estabelecimento"]["atividade_principal"]["descricao"];

                await _oportunidadeService.Cadastrar(oportunidade, json);

                return CreatedAtAction("CadastroOportunidade", new { message = "Oportunidade cadastrada com sucesso." });
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = exception.Message });
            }
        }
    }
}
