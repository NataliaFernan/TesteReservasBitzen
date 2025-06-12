using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReservasRepository.Models;

namespace ReservasRepository.Interfaces
{
        public interface IReservaRepository
        {
            Task<Reserva> Atualizar(Reserva reserva);
            Task<Reserva> Criar(Reserva reserva);
            Task<Reserva?> ObterPorId(int id);
            Task<List<Reserva>> ObterReservas(int idSala, int idUsuario, DateTime? data, bool status = true);
            Task<bool> ExisteHorarioSala(int idSala, DateTimeOffset inicio, DateTimeOffset fim);
        }
}
