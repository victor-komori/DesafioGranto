using Microsoft.AspNetCore.Mvc;
using DesafioGranto.Models.Entities;
using DesafioGranto.Services.Interface;
using DesafioGranto.Models.DTO;

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

        // GET: api/Usuarios/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Usuario>> GetUsuario(int id)
        //{
        //    var usuario = usuarioService();

        //    if (usuario == null)
        //    {
        //        return NotFound();

        //    }

        //    return usuario;
        //}

        /// <summary>
        /// Cadastra um novo usuário.
        /// </summary>
        /// <param name="usuarioCadastro"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CadastroUsuario(UsuarioCadastroDTO usuarioCadastro)
        {
            var usuarioExistente = await _usuarioService.FindById(usuarioCadastro.Email);
            if (usuarioExistente is null)
            {
                Usuario usuario = new();
                usuario.Nome = usuarioCadastro.Nome;
                usuario.Email = usuarioCadastro.Email;
                usuario.Regiao = usuarioCadastro.Regiao;
                _usuarioService.Cadastrar(usuario);
                return CreatedAtAction("CadastroUsuario", new { message = "Usuário cadastrado com sucesso." });
            }
            else
            {
                return Conflict(new { message = $"O e-mail '{usuarioCadastro.Email}' já foi cadastrado. Favor informar um outro e-mail." });
            }

            //_context.Usuario.Add(usuario);
            //await _context.SaveChangesAsync();

            
            //return CreatedAtAction("Cadastro Usuario", new { message = "Usuário cadastrado com sucesso." });
        }
    }
}
