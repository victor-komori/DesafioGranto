using Microsoft.AspNetCore.Mvc;
using DesafioGranto.Models;
using DesafioGranto.Models.Entities;
using DesafioGranto.Models.DTO;
using DesafioGranto.Services.Interface;
using DesafioGranto.Models.Utils;

namespace DesafioGranto.Controllers
{
    [Route("core/oportunidades")]
    [ApiController]
    public class OportunidadesController : ControllerBase
    {
        private readonly IOportunidadeService _oportunidadeService;

        public OportunidadesController(IOportunidadeService oportunidadeService)
        {
            _oportunidadeService = oportunidadeService;
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
        public async Task<IActionResult> CadastroOportunidade(OportunidadeCadastroDTO oportunidadeCadastro)
        {
            Oportunidade oportunidade = new Oportunidade
            {
                Cnpj = CpfCnpjUtils.SemFormatacao(oportunidadeCadastro.Cnpj),
                Nome = oportunidadeCadastro.Nome,
                ValorMonetario = oportunidadeCadastro.Valor
            };

            _oportunidadeService.Cadastrar(oportunidade);

            return CreatedAtAction("CadastroOportunidade", new { message = "Oportunidade cadastrada com sucesso." });
        }
    }
}
