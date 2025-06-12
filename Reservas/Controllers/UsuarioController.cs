using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReservasRepository.Models;
using ReservasRepository.Models.Dto;
using ReservasService.Interfaces;

namespace Reservas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost("entrar")]
        public async Task<ActionResult> Entrar([FromBody] EntrarDto entrarDto)
        {
            try
            {
                var usuarioCriado = await _usuarioService.ObterUsuarioEmailSenha(entrarDto);

                return Ok(usuarioCriado);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao Entrar: {ex.Message}");
            }
        }

        [HttpPost("cadastrar")]
        public async Task<ActionResult> CadastrarUsuario([FromBody] Usuario usuario)
        {
            try
            {
                var usuarioCriado = await _usuarioService.CadastrarUsuario(usuario);

                return Ok(usuarioCriado);
            }
            catch(Exception ex)
            {
                return BadRequest($"Erro ao CadastrarUsuario usuário: {ex.Message}");
            }
        }

        [Authorize]
        [HttpPut("editar")]
        public async Task<ActionResult> EditarUsuario([FromBody] Usuario usuario)
        {
            try
            {
                var usuarioCriado = await _usuarioService.EditarUsuario(usuario);

                return Ok(usuarioCriado);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao EditarUsuario usuário: {ex.Message}");
            }
        }

        [Authorize]
        [HttpDelete("desativar/{id}")]
        public async Task<ActionResult> DesativarUsuario(int id)
        {
            try
            {
                var sucesso = await _usuarioService.DesativarUsuario(id);

                return Ok(sucesso);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao DesativarUsuario usuário: {ex.Message}");
            }
        }
    }
}
