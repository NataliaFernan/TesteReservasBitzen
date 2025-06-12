using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReservasRepository.Models;
using ReservasRepository.Models.Dto;
using ReservasService;
using ReservasService.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Reservas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservaController : ControllerBase
    {
        private readonly IReservaService _reservaService;
        public ReservaController(IReservaService reservaService)
        {
            _reservaService = reservaService;
        }

        [Authorize]
        [HttpPost("cadastrar")]
        public async Task<ActionResult> CadastrarReserva([FromBody] NovaReservaDto reserva)
        {
            try
            {
                var reservaCriada = await _reservaService.CadastrarReserva(reserva);

                return Ok(reservaCriada);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao criar reserva: {ex.Message}");
            }
        }

        [Authorize]
        [HttpDelete("desativar/{id}")]
        public async Task<ActionResult> CancelarReserva(int id)
        {
            try
            {
                var sucesso = await _reservaService.CancelarReserva(id);

                return Ok(sucesso);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao cancelar reserva: {ex.Message}");
            }
        }

        [Authorize]
        [HttpGet("obter-reservas")]
        public async Task<ActionResult> CancelarReserva(int? idSala, int? idUsuario, DateTime? data, bool status = true)
        {
            try
            {
                var sucesso = await _reservaService.ObterReservas(idSala.HasValue ? idSala.Value : 0,idUsuario.HasValue ? idUsuario.Value : 0,data,status);

                return Ok(sucesso);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao cancelar reserva: {ex.Message}");
            }
        }
    }
}
