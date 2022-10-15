using Microsoft.AspNetCore.Mvc;
using DesafioGranto.Models.DTO;
using DesafioGranto.Services.Interface;
using DesafioGranto.Models.Utils;
using DesafioGranto.Models.Entities;

namespace DesafioGranto.Controllers
{
    [Route("core/oportunidades")]
    [ApiController]
    public class OportunidadesController : ControllerBase
    {
        private readonly IOportunidadeService _oportunidadeService;
        private readonly IPublicaService _publicaService;

        public OportunidadesController(IOportunidadeService oportunidadeService, IPublicaService publicaService)
        {
            _oportunidadeService = oportunidadeService;
            _publicaService = publicaService;
        }

        /// <summary>
        /// Cadastra uma nova oportunidade.
        /// </summary>
        /// <param name="oportunidadeCadastro"></param>
        /// <returns></returns>
        [HttpPost]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CadastroOportunidade(OportunidadeCadastroDTO oportunidadeCadastro)
        {
            try
            {
                Oportunidade oportunidade = new Oportunidade
                {
                    Cnpj = CpfCnpjUtils.SemFormatacao(oportunidadeCadastro.Cnpj),
                    Nome = oportunidadeCadastro.Nome,
                    ValorMonetario = oportunidadeCadastro.Valor,
                    DataOportunidade = DateTime.Now
                };
                var json = await _publicaService.ConsultarCnpj(oportunidade.Cnpj);
                oportunidade.RazaoSocial = (string?)json["razao_social"];
                oportunidade.DescricaoAtividade = (string?)json["estabelecimento"]["atividade_principal"]["descricao"];

                await _oportunidadeService.Cadastrar(oportunidade, json);

                return CreatedAtAction("CadastroOportunidade", new { message = "Oportunidade cadastrada com sucesso." });
            } catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = exception.Message });
            }
        }
    }
}
