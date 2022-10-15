using Microsoft.AspNetCore.Mvc;
using DesafioGranto.Models.Entities;
using DesafioGranto.Services.Interface;
using DesafioGranto.Models.DTO;
using DesafioGranto.Models.Enum;

namespace DesafioGranto.Controllers
{
    [Route("core/usuarios")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuariosController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        /// <summary>
        /// Cadastra um novo usuário.
        /// </summary>
        /// <param name="usuarioCadastro"></param>
        /// <returns></returns>
        [HttpPost]
        [Consumes("application/json")]
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
    }
}
