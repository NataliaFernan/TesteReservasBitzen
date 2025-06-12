using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReservasRepository.Models;
using ReservasRepository.Models.Dto;

namespace ReservasService.Interfaces
{
    public interface IReservaService
    {
        Task<Reserva> CadastrarReserva(NovaReservaDto reserva);
        Task<List<Reserva>> ObterReservas(int idSala, int idUsuario, DateTime? data, bool status = true);
        Task<bool> CancelarReserva(int id);
    }
}
