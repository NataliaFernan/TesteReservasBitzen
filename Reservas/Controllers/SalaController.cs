using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReservasRepository.Models;
using ReservasRepository.Models.Dto;
using ReservasService;
using ReservasService.Interfaces;

namespace Reservas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalaController : ControllerBase
    {
        private readonly ISalaService _salaService;
        public SalaController(ISalaService salaService)
        {
            _salaService = salaService;
        }

        [Authorize]
        [HttpPost("cadastrar")]
        public async Task<ActionResult> CadastrarSala([FromBody] SalaDto sala)
        {
            try
            {
                var salaCriada = await _salaService.CadastrarSala(sala);

                return Ok(salaCriada);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao criar sala: {ex.Message}");
            }
        }

        [Authorize]
        [HttpPut("editar")]
        public async Task<ActionResult> EditarSala([FromBody] Sala sala)
        {
            try
            {
                var salaEditada = await _salaService.EditarSala(sala);

                return Ok(salaEditada);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao editar sala {ex.Message}");
            }
        }

        [Authorize]
        [HttpDelete("desativar/{id}")]
        public async Task<ActionResult> DesativarSala(int id)
        {
            try
            {
                var sucesso = await _salaService.DesativarSala(id);

                return Ok(sucesso);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao desativar sala: {ex.Message}");
            }
        }
    }
}
