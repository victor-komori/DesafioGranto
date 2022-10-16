using Microsoft.AspNetCore.Mvc;
using DesafioGranto.Models.Entities;
using DesafioGranto.Services.Interface;
using DesafioGranto.Models.DTO;
using DesafioGranto.Models.Enum;
using System;
using AutoMapper;

namespace DesafioGranto.Controllers
{
    [Route("core/usuario")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IMapper _mapper;

        public UsuariosController(IUsuarioService usuarioService, IMapper mapper)
        {
            _usuarioService = usuarioService;
            _mapper = mapper;
        }

        /// <summary>
        /// Cadastra um novo usuário.
        /// </summary>
        /// <param name="usuarioCadastro"></param>
        /// <returns></returns>
        [HttpPost]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(void), StatusCodes.Status409Conflict)]
        public async Task<IActionResult> CadastroUsuario(UsuarioCadastroDTO usuarioCadastro)
        {
            var usuarioExistente = await _usuarioService.FindByEmail(usuarioCadastro.Email);
            if (usuarioExistente is null)
            {
                Usuario usuario = new();
                usuario.Nome = usuarioCadastro.Nome;
                usuario.Email = usuarioCadastro.Email;
                usuario.Regiao = (Regiao)usuarioCadastro.Regiao;
                _usuarioService.Cadastrar(usuario);
                return CreatedAtAction("CadastroUsuario", new { message = "Usuário cadastrado com sucesso." });
            }
            else
            {
                return Conflict(new { message = $"O e-mail '{usuarioCadastro.Email}' já foi cadastrado. Favor informar um outro e-mail." });
            }
        }

        /// <summary>
        /// Retorna dados do Vendedor com uma lista de todas as oportunidades dele.
        /// </summary>
        /// <param name="email">Email do vendedor</param>
        /// <response code="200">Dados do vendedor retornado com sucesso</response>
        /// <response code="404">Vendedos não encontrado</response>
        /// <response code="500">Erro interno do servidor</response>
        [HttpGet]
        [Route("oportunidades")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(UsuarioDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetUsuarioByEmail([FromHeader]string email)
        {
            try
            {
                var usuario = await _usuarioService.FindByEmail(email);
                if (usuario is null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, new { message = "Vendedor não encontrado" });
                }
                var usuarioMapeado = _mapper.Map<UsuarioDTO>(usuario);
                usuarioMapeado.Oportunidades = _mapper.Map<List<OportunidadeDTO>>(usuario.Oportunidades);
                return StatusCode(StatusCodes.Status200OK, usuarioMapeado);
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = exception.Message });
            }
        }
    }
}
